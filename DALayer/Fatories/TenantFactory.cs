﻿using DALayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public class TenantFactory
    {
        private static bool first = true;
        /*Esto hace magia TenantContext:P*/
        private static ObjectContext getCtx(TenantContext t)
        {
            var adapter = (IObjectContextAdapter)t;
            var objectContext = adapter.ObjectContext;
            return objectContext;
        }
        private static void createTables(TenantContext t) {
            ObjectContext x = getCtx(t);
            string d = x.CreateDatabaseScript();
            t.Database.ExecuteSqlCommand(d);
        }
        public static TenantContext getTenantCxt(string tenant) {
            if (first)
            { 
                Database.SetInitializer<TenantContext>(null);
                first = false;

            }

            string connectionStr = SchemaHandler.getTenantConnectionString(tenant);

            TenantContext t;

            using (var ctx = new AdminContext()) {
                var juego = from j in ctx.Juego
                              where j.nombreJuego.Equals(tenant)
                              select j;
                if (juego.Count<Juego>() == 0)
                {
                    try
                    {
                        SchemaHandler.createTenant(tenant);
                        /*Esto debe llamar a la funcion de creacion de Juego del DJuego*/
                        Juego newJuego = new Juego();
                        newJuego.id = Guid.NewGuid();
                        newJuego.dominio = "domino" + tenant;
                        newJuego.nombreJuego = tenant;
                        ctx.Juego.Add(newJuego);
                        ctx.SaveChangesAsync().Wait();
                        t = new TenantContext(connectionStr, tenant);
                        createTables(t);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                else {
                    t = new TenantContext(connectionStr, tenant);
                }

            } 
            return t;

        }
       
    }
}