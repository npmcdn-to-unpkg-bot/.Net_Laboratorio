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
            receiver.Clean();
            receiver.SetRecursos(requester.GetRecursos());
            receiver.SetMustUpdate(true);
            requester.Return();
            return new List<IInteractionable> { requester, receiver };
        }

        public List<IInteractionable> finalize(IInteractionable requester, IInteractionable receiver)
        {
            requester.GetRecursos().ForEach((rec) => {
                rec.SetAmount(0);
            });
            requester.SetMustUpdate(true); 
            return new List<IInteractionable> { requester, receiver };
        }

       
    }
}
