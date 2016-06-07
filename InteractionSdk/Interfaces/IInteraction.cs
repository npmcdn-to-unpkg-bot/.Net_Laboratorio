using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionSdk.Interfaces
{
    public interface IInteraction
    {
        IConfig GetConfig();
        List<IInteractionable> initialize(IInteractionable requester, IInteractionable receiver);
        List<IInteractionable> exec(IInteractionable requester, IInteractionable receiver);
        List<IInteractionable> finalize(IInteractionable requester, IInteractionable receiver);
    }
}
