using DALayer.Entities;
using DALayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Handlers
{
    public class TenantHandlerEF : ITenantHandler
    {


        public bool tenantExist(string id)
        {
            using (var ctx = new AdminContext())
            {
                var juego = from j in ctx.Juego
                            where j.nombreJuego.Equals(id)
                            select j;
                return juego.Count<Juego>() == 0;
               
            }
        }
    }
}
