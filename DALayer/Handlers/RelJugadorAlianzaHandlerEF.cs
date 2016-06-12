using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Interfaces;
using SharedEntities.Entities;

namespace DALayer.Handlers
{
    public class RelJugadorAlianzaHandlerEF : IRelJugadorAlianzaHandler
    {
        TenantContext ctx;
        public RelJugadorAlianzaHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createRelJugadorAlianza(RelJugadorAlianza r)
        {
            var ali = ctx.Alianza.Where(w => w.id == r.alianza.id).SingleOrDefault();
            var mie = ctx.Jugador.Where(w => w.Id == r.miembro.id).SingleOrDefault();

            Entities.RelJugadorAlianza rja = new Entities.RelJugadorAlianza(ali, mie, r.activo);

            try
            {
                ctx.RelJugadorAlianza.Add(rja);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteRelJugadorAlianza (int id)
        {

            var rja = ctx.RelJugadorAlianza.
                          Where(w => w.id == id).SingleOrDefault();
            try
            {
                ctx.RelJugadorAlianza.Remove(rja);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception e)
            {
                throw e;
            } 
        }

        public void updateRelJugadorAlianza(RelJugadorAlianza rja)
        {
            try
            {
                var rjaTmp = ctx.RelJugadorAlianza
                    .Where(w => w.id == rja.id)
                    .SingleOrDefault();

                if (rjaTmp != null)
                {
                    Entities.Jugador adm = new Entities.Jugador(rja.alianza.administrador.nombre, rja.alianza.administrador.apellido,
                                                                 rja.alianza.administrador.foto, rja.alianza.administrador.nickname, 
                                                                 rja.alianza.administrador.nivel, rja.alianza.administrador.experiencia);
                    Entities.Alianza ali = new Entities.Alianza(rja.alianza.nombre, rja.alianza.descripcion, rja.alianza.foto, adm);
                    Entities.Jugador mie = new Entities.Jugador(rja.miembro.nombre, rja.miembro.apellido, rja.miembro.foto, rja.miembro.nickname, 
                                                                rja.miembro.nivel, rja.miembro.experiencia);

                    rjaTmp.alianza = ali;
                    rjaTmp.miembro = mie;
                    rjaTmp.activo = rja.activo;

                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RelJugadorAlianza getRelJugadorAlianza(int id)
        {
            try
            {
                var rja = (from c in ctx.RelJugadorAlianza
                           where c.id == id
                           select c).SingleOrDefault();

                return rja.getShared();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RelJugadorAlianza> getAllRelJugadorAlianza()
        {
            List<RelJugadorAlianza> listaRel = new List<RelJugadorAlianza>();
            try
            {
                List<Entities.RelJugadorAlianza> relEntities = ctx.RelJugadorAlianza.ToList();
                foreach (Entities.RelJugadorAlianza item in relEntities)
                {
                    listaRel.Add(item.getShared());
                }
                return listaRel;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public List<RelJugadorAlianza> getMiembrosByAlianza (int alianzaId)
        {
            var miembros = new List<RelJugadorAlianza>();
            try
            {
                ctx.Database.Connection.Open();
                List<Entities.RelJugadorAlianza> miembrosTmp = ctx.RelJugadorAlianza.Where(w => w.alianza.id == alianzaId).ToList();
                ctx.Database.Connection.Close();
                foreach (var item in miembrosTmp)
                {
                    miembros.Add(item.getShared());
                }
                return miembros;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
