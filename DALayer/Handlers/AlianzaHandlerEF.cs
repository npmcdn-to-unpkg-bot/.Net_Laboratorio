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
    public class AlianzaHandlerEF : IAlianzaHandler
    {
        TenantContext ctx;
        public AlianzaHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createAlianza(Alianza a)
        {
            var admin = ctx.Jugador.Where(w => w.Id == a.administrador.id).SingleOrDefault();
            Entities.Alianza alli = new Entities.Alianza(a.nombre, a.descripcion, a.foto, admin);

            try
            {
                ctx.Alianza.Add(alli);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteAlianza(int id)
        {
            var alli = (from c in ctx.Alianza
                        where c.id == id
                        select c).SingleOrDefault();
            try
            {
                ctx.Alianza.Remove(alli);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void updateAlianza(Alianza alli)
        {
            try
            {
                var alliTmp = ctx.Alianza
                    .Where(w => w.nombre == alli.nombre)
                    .SingleOrDefault();

                if (alliTmp != null)
                {
                    alliTmp.nombre = alli.nombre;
                    alliTmp.descripcion = alli.descripcion;
                    alliTmp.foto = alli.foto;
                }
                    ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Alianza> getAllAlianzas()
        {
            List<Alianza> alianzas = new List<Alianza>();
            try
            {
                List<Entities.Alianza> alliTmp = ctx.Alianza.ToList();
                foreach (Entities.Alianza item in alliTmp)
                {
                    Alianza all = getAlianza(item.id);
                    alianzas.Add(all);
                }
                return alianzas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Alianza getAlianza(int id)
        {
            try
            {
                var ali = (from c in ctx.Alianza
                           where c.id == id
                           select c).SingleOrDefault();

                return ali.getShared();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Alianza getAlianzaByAdministrador(string id)
        {
            try
            {
                var ali = (from c in ctx.Alianza
                           where c.administrador.Id == id
                           select c).SingleOrDefault();

                if (ali != null)
                {
                    return ali.getShared();
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
