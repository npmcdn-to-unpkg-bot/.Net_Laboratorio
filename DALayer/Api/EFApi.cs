using DALayer.Handlers;
using DALayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Api
{
    public class EFApi : IApi
    {
        private TenantContext ctx;
        private AdminContext actx;
        private AlianzaHandlerEF alianzaHandler;
        private DependenciaHandlerEF dependenciaHandler;
        private HistorialVentasHandlerEF historialVHandler;
        private InvestigacionHandlerEF investigacionHandler;
        private JuegoHandlerEF juegoHandler;
        private RecursosHandlerEF recursosHanlder;
        private MapaNodeHandlerEF mapaHandler;
        private PaquetePaypalHandlerEF paquetePHandler;
        private SolicitudJuegoHandlerEF solicitudJHandler;
        private UnidadHandlerEF unidadHandler;
        private UsuarioHandlerEF usuarioHandler;
        private TenantHandlerEF tenantHandler;
        private RelJugadorEdificioHandlerEF relJugadorEdificioHandler;
        private RelJugadorInvestigacionHandlerEF relJugadorInvestigacionHandler;
        private RelJugadorMapaHandlerEF relJugadorMapaHandler;
        private RelJugadorRecursoHandlerEF relJugadorRecursoHandler;
        private RelJugadorDestacamentoHandlerEF relJugadorDestacamentoHandler;
        private RelJugadorAlianzaHandlerEF relJugadorAlianzaHandler;
        private UiHandlerEF uiHandler;
        private CostoHandlerEF costoHandler;
        private CapacidadHandlerEF capacidadHandler;
        private ProduceHandlerEF produceHandler;
        private IInteractionHandler interactionHandler;
        private IIntStateHandler intStateHandler;
 
        public ITenantHandler getTenantHandler() {
            if (tenantHandler == null)
            {
                tenantHandler = new TenantHandlerEF();
            }
            return tenantHandler;
        }
        public IIntStateHandler getIntStateHandler()
        {
            if (intStateHandler == null)
            {
                intStateHandler = new IntStateHandler(ctx.SchemaName);
            }
            return intStateHandler;
        }
        public IInteractionHandler getInteractionHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (interactionHandler == null)
            {
                interactionHandler = new InteractionHandler(ctx);
            }
            return interactionHandler;
        }

        public IRecursoHandler getRecursoHandler()
        {
            if (ctx == null) {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (recursosHanlder == null) {
                recursosHanlder = new RecursosHandlerEF(ctx);
            }
            return recursosHanlder;
        }

        public IMapaNodeHandler getMapaNodeHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (mapaHandler == null)
            {
                mapaHandler = new MapaNodeHandlerEF(ctx);
            }
            return mapaHandler;
        }

        public void setTenant(string tid)
        {
            ctx = TenantFactory.getTenantCxt(tid);
        }

        public IUnidadHandler getUnidadHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (unidadHandler == null)
            {
                unidadHandler = new UnidadHandlerEF(ctx);
            }
            return unidadHandler;
        }

        public IAlianzaHandler getAlianzaHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (alianzaHandler == null)
            {
                alianzaHandler = new AlianzaHandlerEF(ctx);
            }
            return alianzaHandler;
        }

        public IDependenciaHandler getDependenciaHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (dependenciaHandler == null)
            {
                dependenciaHandler = new DependenciaHandlerEF(ctx);
            }
            return dependenciaHandler;
        }

        public IHistorialVentasHandler getHVHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (historialVHandler == null)
            {
                historialVHandler = new HistorialVentasHandlerEF(ctx);
            }
            return historialVHandler;
        }

        public IInvestigacionHandler getInvestigacionHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (investigacionHandler == null)
            {
                investigacionHandler = new InvestigacionHandlerEF(ctx);
            }
            return investigacionHandler;
        }

        public IJuegoHandler getJuegoHandler()
        {
            if (actx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (juegoHandler == null)
            {
                juegoHandler = new JuegoHandlerEF(actx);
            }
            return juegoHandler;
        }

        public IPaquetePayPalHandler getPPHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (paquetePHandler == null)
            {
                paquetePHandler = new PaquetePaypalHandlerEF(ctx);
            }
            return paquetePHandler;
        }

        public ISolicitudJuegoHandler getSJHandler()
        {
            if (actx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (solicitudJHandler == null)
            {
                solicitudJHandler = new SolicitudJuegoHandlerEF(actx);
            }
            return solicitudJHandler;
        }

        public IUsuarioHandler getUsuarioHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (usuarioHandler == null)
            {
                usuarioHandler = new UsuarioHandlerEF(ctx);
            }
            return usuarioHandler;
        }

        public IRelJugadorEdificioHandler getRelJugadorEdificioHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (relJugadorEdificioHandler == null)
            {
                relJugadorEdificioHandler = new RelJugadorEdificioHandlerEF(ctx);
            }
            return relJugadorEdificioHandler;
        }

        public IRelJugadorMapaHandler getRelJugadorMapaHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (relJugadorMapaHandler == null)
            {
                relJugadorMapaHandler = new RelJugadorMapaHandlerEF(ctx);
            }
            return relJugadorMapaHandler;
        }
        
        public IRelJugadorRecursoHandler getRelJugadorRecursoHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (relJugadorRecursoHandler == null)
            {
                relJugadorRecursoHandler = new RelJugadorRecursoHandlerEF(ctx);
            }
            return relJugadorRecursoHandler;
        }

        public IRelJugadorInvestigacionHandler getRelJugadorInvestigacionHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (relJugadorInvestigacionHandler == null)
            {
                relJugadorInvestigacionHandler = new RelJugadorInvestigacionHandlerEF(ctx);
            }
            return relJugadorInvestigacionHandler;
        }

        public IRelJugadorDestacamentoHandler getRelJugadorDestacamentoHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (relJugadorDestacamentoHandler == null)
            {
                relJugadorDestacamentoHandler = new RelJugadorDestacamentoHandlerEF(ctx);
            }
            return relJugadorDestacamentoHandler;
        }

        public IUiHandler getUiHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (uiHandler == null)
            {
                uiHandler = new UiHandlerEF(ctx);
            }
            return uiHandler;
        }

        public ICostoHandler getCostoHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (costoHandler == null)
            {
                costoHandler = new CostoHandlerEF(ctx);
            }
            return costoHandler;
        }

        public ICapacidadHandler getCapacidadHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (capacidadHandler == null)
            {
                capacidadHandler = new CapacidadHandlerEF(ctx);
            }
            return capacidadHandler;
        }

        public IProduceHandler getProduceHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (produceHandler == null)
            {
                produceHandler = new ProduceHandlerEF(ctx);
            }
            return produceHandler;
        }
    }
}
