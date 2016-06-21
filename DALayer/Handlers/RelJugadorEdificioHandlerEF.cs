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
    public class RelJugadorEdificioHandlerEF : IRelJugadorEdificioHandler
    {
        TenantContext ctx;
        public RelJugadorEdificioHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createRelJugadorEdificio(RelJugadorEdificio r)
        {
            var col = ctx.RelJugadorMapa.Where(w => w.id == r.colonia.id).SingleOrDefault();
            var ed = ctx.Edificio.Where(w => w.id == r.edificio.id).SingleOrDefault();
            
            var rje = new Entities.RelJugadorEdificio(col, ed, r.nivelE, r.finalizaConstruccion);

            try
            {
                ctx.RelJugadorEdificio.Add(rje);

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void bajarNivel(int id)
        {
            try
            {
                var r = ctx.RelJugadorEdificio
                   .Where(w => w.id == id)
                   .SingleOrDefault();

                if (r != null)
                {
                    r.nivelE -= 1;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RelJugadorEdificio subirNivel(int id)
        {
            RelJugadorRecursoHandlerEF jrHandler = new RelJugadorRecursoHandlerEF(ctx);
            try
            {
                var r = ctx.RelJugadorEdificio
                    .Where(w => w.id == id)
                    .SingleOrDefault();

                if (r != null)
                {
                    var edi = r.getShared();
                    DateTime ahora = DateTime.Now;
                    TimeSpan tConstruccion = TimeSpan.FromMinutes(edi.edificio.tiempoInicial);
                    r.finalizaConstruccion = ahora.Add(tConstruccion);

                    List<Entities.Costo> costos = r.edificio.calCostoXNivel(r.nivelE, 1);
                    jrHandler.restarCompra(r.colonia.id, costos);
                    
                    ctx.SaveChangesAsync().Wait();
                }
                return r.getShared();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void executeSubir (int idRel)
        {
            var relJMHandler = new RelJugadorMapaHandlerEF(ctx);

            var r = ctx.RelJugadorEdificio
                    .Where(w => w.id == idRel)
                    .SingleOrDefault();

            r.nivelE += 1;
            ctx.SaveChangesAsync().Wait();
            relJMHandler.actualizarProduccionCapacidad(r.colonia.id);
        }

        public List<RelJugadorEdificio> getEdificiosByColonia(int id)
        {
            var edificios = new List<RelJugadorEdificio>();
            try
            {
                ctx.Database.Connection.Open();
                List<Entities.RelJugadorEdificio> edificiosE = ctx.RelJugadorEdificio.Where(w => w.colonia.id == id).ToList();
                ctx.Database.Connection.Close();
                foreach (var item in edificiosE)
                {
                    edificios.Add(item.getShared());
                }

                return edificios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RelJugadorEdificio getRelJugadorEdificio(int id)
        {
            var rel = ctx.RelJugadorEdificio.Where(w => w.id == id).FirstOrDefault();
            return rel.getShared();
        }
    }
}
