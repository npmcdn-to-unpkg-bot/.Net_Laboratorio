using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLayer.Interfaces;
using SharedEntities.Entities;
using BLayer.Scheduler;
using GameBuildPortal.Controllers;

namespace GameBuildPortal.ControllersFrontApi
{
    public class JugadorDestacamentoController : ApiController
    {
        public IFront blHandler;
        
        public JugadorDestacamentoController()
        {
            blHandler = WebApiConfig.FrontService(Tenantcontroller.getTenantName());
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

        [HttpPut]
        public HttpResponseMessage PutSubirCantidad(int id, RelJugadorDestacamento rjd)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                Boolean compro = blHandler.updateRelJugadorDestacamento(rjd);
                if (compro)
                {
                    var rel = blHandler.getRelJugadorDestacamento(rjd.id);
                    var cant = rjd.cantidad - rel.cantidad;
                    Scheduler.ScheduleUpload<DestacamentoUpload>(Tenantcontroller.getTenantName(), DateTime.Now.ToString(), rjd.id, cant, cant * rel.destacamento.tiempoInicial);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Recursos insuficientes");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}