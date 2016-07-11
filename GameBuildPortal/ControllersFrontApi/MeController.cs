using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLayer.Interfaces;
using SharedEntities.Entities;
using Microsoft.AspNet.Identity;
using GameBuildPortal.Controllers;

namespace GameBuildPortal.ControllersFrontApi
{
    public class MeController : ApiController
    {
        public IFront blHandler;

        public MeController()
        {
            blHandler = WebApiConfig.FrontService(Tenantcontroller.getTenantName());
        }

        [HttpGet]
        public Jugador Get()
        {
            string id = User.Identity.GetUserId();

            Jugador jugador = blHandler.getJugador(id);
            if (jugador == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return jugador;
        }
    }
}