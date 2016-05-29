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
    public class JugadorDestacamentoController : ApiController
    {
        public static IFront blHandler;

        public JugadorDestacamentoController()
        {
            blHandler = WebApiConfig.FrontService("");
        }

        [HttpGet]
        public IEnumerable<RelJugadorDestacamento> Get(int id)
        {
            IEnumerable<RelJugadorDestacamento> destacamentos = blHandler.getDestacamentosByColonia(id);
            if (destacamentos == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return destacamentos;
        }

        //[HttpGet]
        //public IEnumerable<RelJugadorEdificio> Get(Jugador j)
        //{
        //    return blHandler.getMapasByJugador(j);
        //}

        [HttpPut]
        public HttpResponseMessage Put(int id, RelJugadorDestacamento r)
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
                blHandler.updateRelJugadorDestacamento(r);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(RelJugadorDestacamento r)
        {
            if (ModelState.IsValid)
            {
                blHandler.createRelJugadorDestacamento(r);

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
                blHandler.deleteRelJugadorDestacamento(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}