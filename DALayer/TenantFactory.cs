using DALayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public class TenantFactory
    {
        /*Esto hace magia :P*/
        public static TenantContext getTenantCxt(string tenant) {
            using (var ctx = AdminFactory.getAdminCtx()) {
                var juego = from j in ctx.Juego
                              where j.nombreJuego.Equals(tenant)
                              select j;
                if (juego.Count<Juego>() == 0) {
                    try
                    {
                        DBHandler.createTenant(tenant);
                        /*Esto debe llamar a la funcion de creacion de Juego del DJuego*/
                        Juego newJuego = new Juego();
                        newJuego.id = Guid.NewGuid();
                        newJuego.dominio = "domino" + tenant;
                        newJuego.nombreJuego = tenant;
                        ctx.Juego.Add(newJuego);
                        ctx.SaveChangesAsync().Wait();
                    }
                    catch (Exception e) {
                        throw e;
                    }
                }

            }
            return new TenantContext(DBHandler.getTenantConnectionString(tenant), tenant);

        }
    }
}
