using InteractionSdk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Interfaces
{
    public interface IInteractionController
    {
        List<string> AvailableInteractions();
        void LoadInteractionByName(string name);
        IConfig GetConfig();
        void InitializeInteraction(IInteractionable requester, IInteractionable receiver);
    }
}
