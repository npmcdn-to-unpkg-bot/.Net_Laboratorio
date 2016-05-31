using DALayer.Handlers;
using DALayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Api
{
    public class SuperAdminApi: ISuperAdminApi
    {
        private ISolicitudJuegoHandler solicitudJHandler;
        private IJuegoHandler juegoHandler;

        public ISolicitudJuegoHandler getSJHandler()
        {
            if (solicitudJHandler == null)
            {
                solicitudJHandler = new SolicitudJuegoHandlerEF(AdminFactory.getAdminCtx());
            }
            return solicitudJHandler;
        }
        public IJuegoHandler getJuegoHandler()
        {
            if (juegoHandler == null)
            {
                juegoHandler = new JuegoHandlerEF(AdminFactory.getAdminCtx());
            }
            return juegoHandler;
        }
    }
}
