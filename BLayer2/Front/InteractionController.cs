using BLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteractionSdk.Interfaces;
using Comercio.Clases;
using SharedEntities.Entities;

namespace BLayer.Front
{
    public class InteractionController : IInteractionController
    {
        private IInteraction current;

        public List<string> AvailableInteractions()
        {
            ///this  must retrive the interactions available on the game, we must create an config entitie to handle it 
           return new List<string> { "Comercio" };
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
            ///Due the name selected on AvailableInteraction we must to know which library load trough reflection
            current = new Ataque.Clases.Ataque();
        }
    }
}
