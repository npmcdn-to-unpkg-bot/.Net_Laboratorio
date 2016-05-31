using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLayer.Interfaces;
using SharedEntities.Entities;
using Microsoft.AspNet.Identity;

namespace GameBuildPortal.ControllersFrontApi
{
    public class JugadorMapaController : ApiController
    {
        public static IFront blHandler;

        public JugadorMapaController()
        {
            blHandler = WebApiConfig.FrontService(null);
        }

        [HttpGet]
        public RelJugadorMapa Get(int id)
        {
            RelJugadorMapa colonia = blHandler.getRelJugadorMapa(id);
            if (colonia == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return colonia;
        }

        [HttpGet]
        public IEnumerable<RelJugadorMapa> Get()
        {
            string id = User.Identity.GetUserId();
            return blHandler.getMapasByJugador(id);
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, RelJugadorMapa r)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != r.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateRelJugadorMapa(r);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(RelJugadorMapa r)
        {
            if (ModelState.IsValid)
            {
                blHandler.createRelJugadorMapa(r);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, r);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { controller = "Admin" }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                blHandler.deleteRelJugadorMapa(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}