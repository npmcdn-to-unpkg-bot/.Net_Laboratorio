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
    public class JugadorMapaController : ApiController
    {
        public static IFront blHandler;

        public JugadorMapaController()
        {
            blHandler = WebApiConfig.FrontService("");
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
        public IEnumerable<MapaNode> Get()
        {
            return blHandler.getAllMapas();
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, MapaNode mapa)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != mapa.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateMapa(mapa);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(MapaNode mapa)
        {
            if (ModelState.IsValid)
            {
                blHandler.createMapa(mapa);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, mapa);
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
                blHandler.deleteMapa(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}