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
    public class JugadorInvestigacionController : ApiController
    {
        public static IFront blHandler;

        public JugadorInvestigacionController()
        {
            blHandler = WebApiConfig.FrontService("");
        }

        [HttpGet]
        public IEnumerable<RelJugadorInvestigacion> Get(int id)
        {
            IEnumerable<RelJugadorInvestigacion> investigaciones = blHandler.getInvestigacionesByColonia(id);
            if (investigaciones == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return investigaciones;
        }

        //[HttpGet]
        //public IEnumerable<RelJugadorEdificio> Get(Jugador j)
        //{
        //    return blHandler.getMapasByJugador(j);
        //}

        [HttpPut]
        public HttpResponseMessage Put(int id, RelJugadorInvestigacion r)
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
                blHandler.updateRelJugadorInvestigacion(r);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(RelJugadorInvestigacion r)
        {
            if (ModelState.IsValid)
            {
                blHandler.createRelJugadorInvestigacion(r);

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
                blHandler.deleteRelJugadorInvestigacion(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}