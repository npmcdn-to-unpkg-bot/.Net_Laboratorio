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
                
                interactionHandler.LoadInteractionByName(intera.tipo);
 
                //blHandler.createRelJugadorAlianza(rja);

                Interactuable requester = new Interactuable(intera.requester.id);
                Interactuable receiver = new Interactuable(intera.receiver.id);

                if (interactionHandler.GetConfig().isReqNeedFloat())
                {
                    List<IDestacamento> flota = new List<IDestacamento>();
                    List<IDestacamento> current = blHandler.getDestacamentosByColonia(intera.requester.id).Cast<IDestacamento>().ToList();
                    intera.requester.flota.ToList<Tupla>().ForEach((f) =>
                    {
                        var dest = current.Where(c => c.GetId() == f.id).FirstOrDefault();
                        if (dest != null)
                        {
                            flota.Add(dest);
                        }
                    });
                    requester.SetFlota(flota);
                }
                List<IResources> recurso = new List<IResources>();
                List<IResources> rlist = blHandler.getRecursosByColonia(intera.requester.id).Cast<IResources>().ToList();

                rlist.ForEach((f) =>
                {
                    var dest = intera.requester.recurso.ToList<Tupla>().Where(c => c.id == f.GetId()).FirstOrDefault();
                    if (dest != null && interactionHandler.GetConfig().isReqNeedRecursos())
                    {
                        f.SetAmount(dest.value);
                    }

                    recurso.Add(f);
                });
                requester.SetRecursos(recurso);

                if (interactionHandler.GetConfig().isRecNeedFloat())
                {
                    List<IDestacamento> flotaRec = new List<IDestacamento>();
                    List<IDestacamento> currentRec = blHandler.getDestacamentosByColonia(intera.receiver.id).Cast<IDestacamento>().ToList();
                    intera.receiver.flota.ToList<Tupla>().ForEach((f) =>
                    {
                        var dest = currentRec.Where(c => c.GetId() == f.id).FirstOrDefault();
                        if (dest != null)
                        {
                            flotaRec.Add(dest);
                        }
                    });
                    receiver.SetFlota(flotaRec);
                }
                if (interactionHandler.GetConfig().isRecNeedRecursos())
                {
                    List<IResources> recursoRec = new List<IResources>();
                    List<IResources> rlistRec = blHandler.getRecursosByColonia(intera.requester.id).Cast<IResources>().ToList();


                    rlistRec.ForEach((f) =>
                    {
                        var dest = intera.receiver.recurso.ToList<Tupla>().Where(c => c.id == f.GetId()).FirstOrDefault();
                        if (dest != null && interactionHandler.GetConfig().isRecNeedRecursos())
                        {
                            f.SetAmount(dest.value);
                        }

                        recursoRec.Add(f);
                    });
                    receiver.SetRecursos(recursoRec);
                }
                interactionHandler.InitializeInteraction(requester, receiver);
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
