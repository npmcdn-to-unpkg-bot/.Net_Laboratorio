using DALayer.Handlers;
using DALayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Api
{
    public class EFApi: IApi
    {
        private TenantContext ctx;
        private AdminContext actx;
        private AlianzaHandlerEF alianzaHandler;
        private DependenciaHandlerEF dependenciaHandler;
        private FlotaHandlerEF flotaHandler;
        private HistorialVentasHandlerEF historialVHandler;
        private InvestigacionHandlerEF investigacionHandler;
        private JuegoHandlerEF juegoHandler;
        private RecursosHandlerEF recursosHanlder;
        private MapaNodeHandlerEF mapaHandler;
        private PaquetePaypalHandlerEF paquetePHandler;
        private SolicitudJuegoHandlerEF solicitudJHandler;
        private UnidadHandlerEF unidadHandler;
        private UsuarioHandlerEF usuarioHandler;
        
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

        public IFlotaHandler getFlotaHandler()
        {
            if (ctx == null)
            {
                throw new Exception("Tenes que llamar a la funcion setTenant despues de inicializar esta clase");
            }
            if (flotaHandler == null)
            {
                flotaHandler = new FlotaHandlerEF(ctx);
            }
            return flotaHandler;
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
    }
}
