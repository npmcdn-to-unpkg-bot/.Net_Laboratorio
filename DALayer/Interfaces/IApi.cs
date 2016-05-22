using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Interfaces
{
    public interface IApi
    {
        IAlianzaHandler getAlianzaHandler();
        IDependenciaHandler getDependenciaHandler();
        IFlotaHandler getFlotaHandler();
        IHistorialVentasHandler getHVHandler();
        IInvestigacionHandler getInvestigacionHandler();
        IJuegoHandler getJuegoHandler();
        IRecursoHandler getRecursoHandler();
        IMapaNodeHandler getMapaNodeHandler();
        IPaquetePayPalHandler getPPHandler();
        ISolicitudJuegoHandler getSJHandler();
        IUnidadHandler getUnidadHandller();
        void setTenant(string tid);
    }
}
