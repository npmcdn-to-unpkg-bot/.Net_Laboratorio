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
    public class JugadorAlianzaController : ApiController
    {
        public static IFront blHandler;

        public JugadorAlianzaController ()
        {
            blHandler = WebApiConfig.FrontService(Tenantcontroller.getTenantName());
        }

        [HttpGet]
        public IEnumerable<RelJugadorAlianza> GetByAlianza (int id)
        {
            IEnumerable<RelJugadorAlianza> miembros = blHandler.getMiembrosByAlianza(id);
            if (miembros == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return miembros;
        }

        [HttpPost]
        public HttpResponseMessage Post(RelJugadorAlianza rja)
        {
            if (ModelState.IsValid)
            {
                blHandler.createRelJugadorAlianza(rja);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, rja);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteRelJugadorAlianza (int id)
        {
            try
            {
                blHandler.deleteRelJugadorAlianza(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            };
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}