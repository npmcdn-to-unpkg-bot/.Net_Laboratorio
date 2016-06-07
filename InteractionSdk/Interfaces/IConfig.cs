using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionSdk.Interfaces
{
    public interface IConfig
    {
        bool isReqNeedFloat();
        bool isReqNeedRecursos();
        bool isRecNeedFloat();
        bool isRecNeedRecursos();
        bool NeedConfirmation();
        string GetName();
    }
}
