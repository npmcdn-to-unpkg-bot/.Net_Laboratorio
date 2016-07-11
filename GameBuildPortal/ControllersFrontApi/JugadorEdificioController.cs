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
    public class JugadorEdificioController : ApiController
    {
        public static IFront blHandler;

        public JugadorEdificioController()
        {
            blHandler = WebApiConfig.FrontService(Tenantcontroller.tenant);
        }

        [HttpGet]
        public IEnumerable<RelJugadorEdificio> GetByColonia(int id)
        {
            IEnumerable<RelJugadorEdificio> edicicios = blHandler.getEdificiosByColonia(id);
            if (edicicios == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return edicicios;
        }

        [HttpPut]
        public HttpResponseMessage PutSubirNivel(int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            try
            {
                var compro = blHandler.subirNivelRelJE(id);
                if (compro != null)
                {
                    var rel = blHandler.getRelJugadorEdificio(id);
                    Scheduler.ScheduleUpload<EdificioUpload>(Tenantcontroller.tenant, DateTime.Now.ToString(), id, rel.nivelE + 1, rel.edificio.tiempoInicial);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, "Recursos insuficientes");
                }
                //blHandler.executeSubirRelJE(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteBajarNivel(int id)
        {
            try
            {
                blHandler.bajarNivel(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}