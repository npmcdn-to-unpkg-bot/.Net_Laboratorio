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
        private RecursosHandlerEF recursosHanlder;
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

        public void setTenant(string tid)
        {
            ctx = TenantFactory.getTenantCxt(tid);
        }
    }
}
