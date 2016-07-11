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
    public class JugadorMapaController : ApiController
    {
        public static IFront blHandler;

        public JugadorMapaController()
        {
            blHandler = WebApiConfig.FrontService(Tenantcontroller.getTenantName());
        }

        [HttpGet]
        public RelJugadorMapa Get(int id)
        {
            RelJugadorMapa colonia = blHandler.getRelJugadorMapa(id);
            if (colonia == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return colonia;
        }

        [HttpGet]
        public IEnumerable<RelJugadorMapa> Get()
        {
            string id = User.Identity.GetUserId();
            return blHandler.getMapasByJugador(id);
        }

        [HttpPost]
        public IEnumerable<RelJugadorMapa> Post(int[] coordenada)
        {
            return blHandler.getColoniasPorVista(coordenada);
        }
    }
}