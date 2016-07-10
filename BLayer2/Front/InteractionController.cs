using BLayer.Interfaces;
using System.Collections.Generic;
using InteractionSdk.Interfaces;
using Ataque.Clases;
using SharedEntities.Entities;
using System;
using DALayer.Interfaces;
using MongoDB.Bson;
using System.Linq;

namespace BLayer.Front
{
    public class InteractionController : IInteractionController
    {
        private IApi builder;
        private IInteraction current;

        public InteractionController(string tId, IApi gc)
        {
            builder = gc;
            tId = tId.Replace(" ", "_");
            builder.setTenant(tId);

            // testIntearction();


        }

        public List<string> AvailableInteractions()
        {
            ///this  must retrive the interactions available on the game, we must create an config entitie to handle it 
           return new List<string> { "Comercio" };
        }

        public IEnumerable<Interaction> GetAllInteractionsByColonia(int id)
        {
            return builder.getInteractionHandler().GetAllInteractionsByColonia(id);
        }

        public IConfig GetConfig()
        {
            return current.GetConfig();
        }

        public IntReporte GetReportById(int id)
        { 
            IntReporte rep = new IntReporte();
            rep.states = new List<States>();
            Interaction interaction = builder.getInteractionHandler().GetInteraction(id);

            rep.Fecha = interaction.Fecha;
            rep.receiver = builder.getRelJugadorMapaHandler().getRelJugadorMapa(interaction.receiverId).jugador.email;
            rep.requester = builder.getRelJugadorMapaHandler().getRelJugadorMapa(interaction.requesterId).jugador.email;

            List <IntState>  states = builder.getIntStateHandler().GetAllIntStateByInteraction(id);
            states.ForEach((state) => {
                 
                Interactuable rec = GetIntFromMeta(state.receiver);
                Interactuable req = GetIntFromMeta(state.requester);
                States status = new States(); 
                status.state = state.state;
                status.rec = rec;
                status.req = req;
                if (state.winnerId != -1) {
                    rep.winner = (interaction.receiverId == state.winnerId) ? rep.receiver : rep.requester;
                }
                rep.states.Add(status);
            });
            return rep;
        }

        public Interactuable GetIntFromMeta(InteractuableMetadata meta)
        {
            Interactuable interactuable = new Interactuable(meta.interactuableID);
            interactuable.setCapacidad(meta.capacidad);
            if (meta.returnToBase)
            {
                interactuable.Return();
            }
            var recursos = builder.getRelJugadorRecursoHandler().getRecursosByColonia(meta.interactuableID);
            var destacamento = builder.getRelJugadorDestacamentoHandler().getDestacamentosByColonia(meta.interactuableID);

            var recursoToAssign = new List<RelJugadorRecurso>();
            var flotaToAssign = new List<RelJugadorDestacamento>();
            var defensaToAssign = new List<RelJugadorDestacamento>();
            foreach (var rec in meta.recursos)
            {
                int id = -1;
                int value = -1;
                foreach (var s in rec.ToBsonDocument().ToArray())
                {
                    if (s.Name.Equals("_id"))
                    {
                        id = s.Value.ToInt32();
                    }
                    else {
                        value = s.Value.ToInt32();
                    }
                }
                var recurso = recursos.Where(c => c.recurso.id == id).ToList().First();
                recurso.cantidadR = value;
                recursoToAssign.Add(recurso);

            }
            foreach (var rec in meta.flota)
            {
                int id = -1;
                int value = -1;
                foreach (var s in rec.ToBsonDocument().ToArray())
                {

                    if (s.Name.Equals("_id"))
                    {
                        id = s.Value.ToInt32();
                    }
                    else {
                        value = s.Value.ToInt32();
                    }

                }
                var flota = destacamento.Where(c => c.destacamento.id == id).ToList().First();
                flota.cantidad = value;
                flotaToAssign.Add(flota);
            }
            foreach (var rec in meta.defensa)
            {
                int id = -1;
                int value = -1;
                foreach (var s in rec.ToBsonDocument().ToArray())
                {
                    if (s.Name.Equals("_id"))
                    {
                        id = s.Value.ToInt32();
                    }
                    else {
                        value = s.Value.ToInt32();

                    }
                }
                var defensa = destacamento.Where(c => c.destacamento.id == id).ToList().First();
                defensa.cantidad = value;
                defensaToAssign.Add(defensa);

            }
            interactuable.SetDefensas(defensaToAssign.Cast<IDestacamento>().ToList());
            interactuable.SetRecursos(recursoToAssign.Cast<IResources>().ToList());
            interactuable.SetFlota(flotaToAssign.Cast<IDestacamento>().ToList());
            return interactuable;
        }

        public void InitializeInteraction(IInteractionable requester, IInteractionable receiver)
        {
            InteractionEngine engine = new InteractionEngine(current, "newT2");
            engine.setRequester(requester);
            engine.setReceiver(receiver);
            engine.start();
        }

        public void LoadInteractionByName(string name)
        {
            name = name.ToLower();
            if (name.Equals("atacar")){
                current = new Ataque.Clases.Ataque();
            } 
            else if (name.Equals("comercializar"))
            {
                current = new Comercio.Clases.Comercio();
            }
            ///Due the name selected on AvailableInteraction we must to know which library load trough reflection
            
        }
    }
}
