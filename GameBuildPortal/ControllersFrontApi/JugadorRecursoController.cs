using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLayer.Interfaces;
using SharedEntities.Entities;
using GameBuildPortal.Controllers;

namespace GameBuildPortal.ControllersFrontApi
{
    public class JugadorRecursoController : ApiController
    {
        public static IFront blHandler;

        public JugadorRecursoController()
        {
            blHandler = WebApiConfig.FrontService(Tenantcontroller.tenant);
        }

        [HttpGet]
        public IEnumerable<RelJugadorRecurso> GetByColonia(int id)
        {
            IEnumerable<RelJugadorRecurso> recurso = blHandler.getRecursosByColonia(id);
            if (recurso == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return recurso;
        }
    }
}