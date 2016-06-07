using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionSdk.Interfaces
{
    public interface IInteractionable
    {
        int GetCapacidad();
        List<IDestacamento> GetFlota();
        List<IDestacamento> GetDefensas();
        List<IResources> GetRecursos();

        void SetFlota(List<IDestacamento> ds);
        void SetDefensas(List<IDestacamento> ds);
        void setCapacidad(int cap);
        void SetRecursos(List<IResources> rs);
        int GetID();
        bool GetMustUpdate();
        void SetMustUpdate(bool v);

        void Return();
        void Send();
        bool mustSend(); 
        bool getReturn();
    }
}
