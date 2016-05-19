using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Interfaces
{
    public interface IApi
    {
        IRecursoHandler getRecursoHandler();
        IMapaNodeHandler getMapaNodeHandler();
        void setTenant(string tid);
    }
}
