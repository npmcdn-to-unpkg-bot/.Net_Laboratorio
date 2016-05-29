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
    public class JugadorRecursoController : ApiController
    {
        public static IFront blHandler;

        public JugadorRecursoController()
        {
            blHandler = WebApiConfig.FrontService("");
        }

        [HttpGet]
        public IEnumerable<RelJugadorRecurso> Get(int id)
        {
            IEnumerable<RelJugadorRecurso> recurso = blHandler.getRecursosByColonia(id);
            if (recurso == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return recurso;
        }

        //[HttpGet]
        //public IEnumerable<RelJugadorMapa> Get(Jugador j)
        //{
        //    return blHandler.getMapasByJugador(j);
        //}

        [HttpPut]
        public HttpResponseMessage Put(int id, RelJugadorRecurso r)
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
                blHandler.updateRelJugadorRecurso(r);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(RelJugadorRecurso r)
        {
            if (ModelState.IsValid)
            {
                blHandler.createRelJugadorRecurso(r);

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
                blHandler.deleteRelJugadorRecurso(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}