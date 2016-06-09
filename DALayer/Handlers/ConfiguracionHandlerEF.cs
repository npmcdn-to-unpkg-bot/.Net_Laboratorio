using DALayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;
using System.Data.Entity.Validation;

namespace DALayer.Handlers
{
    public class ConfiguracionHandlerEF : IConfiguracionHandler
    {
        TenantContext ctx;

        public ConfiguracionHandlerEF(TenantContext tc) {
            ctx = tc;
        }

        public void createConf(Configuracion conf)
        {
            Entities.Configuracion u = new Entities.Configuracion(conf.css, conf.nombre, conf.titulo, conf.idAppFace, conf.claveAppFace);
            try
            {
                ctx.Configuracion.Add(u);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void deleteConf(int id)
        {
            var u = (from c in ctx.Configuracion
                       where c.id == id
                        select c).SingleOrDefault();
            try
            {
                ctx.Configuracion.Remove(u);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Configuracion getConfiguracion(int id)
        {
            try
            {
                var u = (from c in ctx.Configuracion
                         where c.id == id
                           select c).SingleOrDefault();

                if (u != null)
                {
                    return u.getShared();
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateConf(Configuracion conf)
        {
            try
            {
                var c = ctx.Configuracion.First();

                if (c != null)
                {
                    c.css = conf.css;
                    c.nombre = conf.nombre;
                    c.titulo = conf.titulo;
                    c.idAppFace = conf.idAppFace;
                    c.claveAppFace = conf.claveAppFace;
                    ctx.SaveChangesAsync().Wait();
                }
                else
                {
                    createConf(conf);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
