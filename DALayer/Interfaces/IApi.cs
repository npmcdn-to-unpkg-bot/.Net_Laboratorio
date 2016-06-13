using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Interfaces
{
    public interface IApi
    {
        ITenantHandler getTenantHandler();
        IAlianzaHandler getAlianzaHandler();
        IDependenciaHandler getDependenciaHandler();
        IHistorialVentasHandler getHVHandler();
        IInvestigacionHandler getInvestigacionHandler();
        IJuegoHandler getJuegoHandler();
        IRecursoHandler getRecursoHandler();
        IMapaNodeHandler getMapaNodeHandler();
        IPaquetePayPalHandler getPPHandler();
        IUnidadHandler getUnidadHandler();
        IUsuarioHandler getUsuarioHandler();
        IRelJugadorEdificioHandler getRelJugadorEdificioHandler();
        IRelJugadorInvestigacionHandler getRelJugadorInvestigacionHandler();
        IRelJugadorMapaHandler getRelJugadorMapaHandler();
        IRelJugadorRecursoHandler getRelJugadorRecursoHandler();
        IRelJugadorDestacamentoHandler getRelJugadorDestacamentoHandler();
        IRelJugadorAlianzaHandler getRelJugadorAlianzaHandler();
        IConfiguracionHandler getUiHandler(); 
        ICostoHandler getCostoHandler();
        ICapacidadHandler getCapacidadHandler();
        IProduceHandler getProduceHandler();
 
        IInteractionHandler getInteractionHandler();
        IIntStateHandler getIntStateHandler();
        void setTenant(string tid);
    }
}
