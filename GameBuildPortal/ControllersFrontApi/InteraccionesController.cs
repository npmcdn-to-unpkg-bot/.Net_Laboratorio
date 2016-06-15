using BLayer.Interfaces;
using BLayer.Front;
using GameBuildPortal.ControllersApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using InteractionSdk.Interfaces;
using SharedEntities.Entities;
using Microsoft.AspNet.Identity;

namespace GameBuildPortal.ControllersFrontApi
{
    public class InteraccionesController : ApiController
    {
        public static IFront blHandler;
        private IInteractionController interactionHandler;

        public InteraccionesController()
        {
            blHandler = WebApiConfig.FrontService(null);
            interactionHandler = WebApiConfig.InteractionService(null);
        }

        [HttpGet]
        public object Get(string nombre)
        {
            interactionHandler.LoadInteractionByName(nombre);
            IConfig confg = interactionHandler.GetConfig();
            object obj = new {
                reqFlota = confg.isReqNeedFloat(),
                reqRec = confg.isReqNeedRecursos(),
                recFlota = confg.isRecNeedFloat(),
                recRec = confg.isRecNeedRecursos()
            };
            return obj;
        }

        [HttpGet]
        public IEnumerable<Interaction> Get()
        {
            string id = User.Identity.GetUserId();
            List<RelJugadorMapa> colonias = blHandler.getMapasByJugador(id);
            int coloniaId = colonias.FirstOrDefault().id;

            return interactionHandler.GetAllInteractionsByColonia(coloniaId);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] InteraccionConfig intera)
        {

            if (ModelState.IsValid)
            {
                //blHandler.createRelJugadorAlianza(rja);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}
