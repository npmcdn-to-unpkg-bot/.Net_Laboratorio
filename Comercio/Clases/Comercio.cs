using InteractionSdk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.Clases
{
    public class Comercio : IInteraction
    {
        public IConfig GetConfig()
        {
            return new Config();
        }

        public List<IInteractionable> initialize(IInteractionable requester, IInteractionable receiver)
        {
            requester.Send();
            return new List<IInteractionable> { requester, receiver };
        }
        public List<IInteractionable> exec(IInteractionable requester, IInteractionable receiver)
        {
            receiver.SetRecursos(requester.GetRecursos());
            requester.Return();
            receiver.SetMustUpdate(true);
            return new List<IInteractionable> { requester, receiver };
        }

        public List<IInteractionable> finalize(IInteractionable requester, IInteractionable receiver)
        {
            requester.SetMustUpdate(true); 
            return new List<IInteractionable> { requester, receiver };
        }

       
    }
}
