using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLayer.Interfaces;
using SharedEntities.Entities;

namespace GameBuildPortal.ControllersFrontApi
{
    public class JugadorEdificioController : ApiController
    {
        public static IFront blHandler;

        public JugadorEdificioController()
        {
            blHandler = WebApiConfig.FrontService(null);
        }

        [HttpGet]
        public IEnumerable<RelJugadorEdificio> Get(int id)
        {
            IEnumerable<RelJugadorEdificio> edicicios = blHandler.getEdificiosByColonia(id);
            if (edicicios == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return edicicios;
        }

        //[HttpGet]
        //public IEnumerable<RelJugadorEdificio> Get(Jugador j)
        //{
        //    return blHandler.getMapasByJugador(j);
        //}

        [HttpPut]
        public HttpResponseMessage Put(int id, RelJugadorEdificio r)
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
                blHandler.updateRelJugadorEdificio(r);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(RelJugadorEdificio r)
        {
            if (ModelState.IsValid)
            {
                blHandler.createRelJugadorEdificio(r);

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
                blHandler.deleteRelJugadorEdificio(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}