using BLayer.Interfaces;
using System.Collections.Generic;
using InteractionSdk.Interfaces;
using Ataque.Clases;
using SharedEntities.Entities;
using System;
using DALayer.Interfaces;

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
