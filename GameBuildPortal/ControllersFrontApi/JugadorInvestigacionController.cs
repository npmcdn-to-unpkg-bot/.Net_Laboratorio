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
    public class JugadorInvestigacionController : ApiController
    {
        public static IFront blHandler;

        public JugadorInvestigacionController()
        {
            blHandler = WebApiConfig.FrontService(Tenantcontroller.tenant);
        }

        [HttpGet]
        public IEnumerable<RelJugadorInvestigacion> GetByColonia(int id)
        {
            IEnumerable<RelJugadorInvestigacion> investigaciones = blHandler.getInvestigacionesByColonia(id);
            if (investigaciones == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return investigaciones;
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
                var rel = blHandler.getRelJugadorInvestigacion(id);
                Scheduler.ScheduleUpload<InvestigacionUpload>(Tenantcontroller.tenant, DateTime.Now.ToString(), id, rel.nivel + 1, rel.investigacion.tiempoInicial);
                blHandler.subirNivelI(id);
                //blHandler.executeSubirRelJI(id);
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
                blHandler.bajarNivelI(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}