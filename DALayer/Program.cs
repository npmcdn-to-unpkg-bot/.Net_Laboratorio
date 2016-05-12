using DALayer.Entities;
using System;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace DALayer
{
    class Program
    {
        public static object ConfigurationManager { get; private set; }

        static void Main(string[] args)
        {


            /*  AdminContext actxt = new AdminContext();
              actxt.SolicitudJuegos.Add(new SolicitudJuego());
              actxt.SaveChangesAsync();
              string tenant = "tetetete2";
              DBHandler.createTenant(tenant);
              TenantContext tctxt = new TenantContext(DBHandler.getTenantConnectionString(tenant), tenant);
              tctxt.Jugador.Add(new Jugador());
              tctxt.SaveChangesAsync();*/
            TenantContext tctxt = TenantFactory.getTenantCxt("sabeloPelo");
            Jugador s = new Jugador();
            s.apellido = DateTime.Now.Millisecond.ToString();
            s.Id = Guid.NewGuid();
            tctxt.Jugador.Add(s);
            tctxt.SaveChangesAsync().Wait();

        }

    }
}
