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
    public class JugadorAlianzaController : ApiController
    {
        public static IFront blHandler;

        public JugadorAlianzaController ()
        {
            blHandler = WebApiConfig.FrontService(null);
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
    }
}