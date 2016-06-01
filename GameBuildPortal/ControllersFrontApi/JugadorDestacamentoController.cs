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
            blHandler = WebApiConfig.FrontService(null);
        }

        [HttpGet]
        public IEnumerable<RelJugadorDestacamento> GetByColonia(int id)
        {
            IEnumerable<RelJugadorDestacamento> destacamentos = blHandler.getDestacamentosByColonia(id);
            if (destacamentos == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return destacamentos;
        }

        [HttpPost]
        public HttpResponseMessage PostSubirCantidad(int id, int cant)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                blHandler.subirCantidadDestacamento(id, cant);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteBajarCantidad(int id, int baja)
        {
            try
            {
                blHandler.bajarCantidadDestacamento(id, baja);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}