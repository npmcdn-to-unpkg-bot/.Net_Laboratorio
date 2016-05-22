using DALayer.Entities;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace DALayer
{
    class Program
    {
        public static object ConfigurationManager { get; private set; }

        static void Main(string[] args)
        {
            Jugador s = new Jugador();
            s.apellido = DateTime.Now.Millisecond.ToString();
            //s.Id = Guid.NewGuid();
             using (TenantContext t2 = TenantFactory.getTenantCxt("sch3emas5238"))
             {
                  t2.Set<Jugador>().Add(s);
                  t2.SaveChangesAsync().Wait();
        }
            using (TenantContext t = TenantFactory.getTenantCxt("sch3emas5138"))
            {
                t.Set<Jugador>().Add(s);
                t.SaveChangesAsync().Wait();
            }
            /*  Database.SetInitializer<TenantContext>(null);
              TenantContext t = TenantFactory.getTenantCxt("sch3emas5138");
              TenantContext t2 = TenantFactory.getTenantCxt("sch3emas5238");

              ObjectContext x = getCtx(t);
              ObjectContext x2 = getCtx(t2);

              t.Database.ExecuteSqlCommand(x.CreateDatabaseScript());
              t.Database.ExecuteSqlCommand(x2.CreateDatabaseScript()); 
            */
        }
        private static ObjectContext getCtx(TenantContext t) {

            var adapter = (IObjectContextAdapter)t;
            var objectContext = adapter.ObjectContext;
            return objectContext;
        } 
    }
}
