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
    public class RelJugadorInvestigacionHandlerEF : IRelJugadorInvestigacionHandler
    {
        TenantContext ctx;
        public RelJugadorInvestigacionHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createRelJugadorInvestigacion(RelJugadorInvestigacion r)
        {
            var col = ctx.RelJugadorMapa.Where(w => w.id == r.colonia.id).SingleOrDefault();
            var inv = ctx.Investigacion.Where(w => w.id == r.investigacion.id).SingleOrDefault();

            List<Entities.Costo> cos = new List<Entities.Costo>();
            foreach (var item in r.investigacion.costos)
            {
                var rec = ctx.Recurso.Where(w => w.id == item.recurso.id).SingleOrDefault();
                var prod = ctx.Producto.Where(w => w.id == item.idProducto).SingleOrDefault();
                var c = new Entities.Costo(rec, prod, item.valor, item.incrementoNivel);
                cos.Add(c);
            }

            Entities.RelJugadorInvestigacion rji = new Entities.RelJugadorInvestigacion(col, inv, r.nivel, r.finalizaConstruccion);
            
            try
            {
                ctx.RelJugadorInvestigacion.Add(rji);

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteRelJugadorInvestigacion(int id)
        {
            var rji = (from c in ctx.RelJugadorInvestigacion
                       where c.id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.RelJugadorInvestigacion.Remove(rji);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateRelJugadorInvestigacion(RelJugadorInvestigacion rji)
        {
            try
            {
                var rjiTmp = ctx.RelJugadorInvestigacion
                    .Where(w => w.id == rji.id)
                    .SingleOrDefault();

                if (rjiTmp != null)
                {
                    rjiTmp.nivel = rji.nivel;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RelJugadorInvestigacion> getInvestigacionesByColonia(int id)
        {
            var investigaciones = new List<RelJugadorInvestigacion>();
            try
            {
                ctx.Database.Connection.Open();
                List<Entities.RelJugadorInvestigacion> invE = ctx.RelJugadorInvestigacion.Where(w => w.colonia.id == id).ToList();
                ctx.Database.Connection.Close();
                foreach (var item in invE)
                {
                    investigaciones.Add(item.getShared());
                }
                return investigaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RelJugadorInvestigacion subirNivelI(int id)
        {
            RelJugadorRecursoHandlerEF jrHandler = new RelJugadorRecursoHandlerEF(ctx);
            try
            {
                var r = ctx.RelJugadorInvestigacion
                    .Where(w => w.id == id)
                    .SingleOrDefault();

                if (r != null)
                {
                    var inv = r.getShared();
                    List<Entities.Costo> costos = r.investigacion.calCostoXNivel(r.nivel, 1);
                    Boolean compro = jrHandler.restarCompra(r.colonia.id, costos);
                    if (compro == false)
                    {
                        return null;
                    }

                    DateTime ahora = DateTime.Now;
                    TimeSpan tConstruccion = TimeSpan.FromSeconds(inv.investigacion.tiempoInicial);
                    r.finalizaConstruccion = ahora.Add(tConstruccion);

                    ctx.SaveChangesAsync().Wait();
                }
                return r.getShared();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void executeSubir(int idRel)
        {
            var relJMHandler = new RelJugadorMapaHandlerEF(ctx);
            var r = ctx.RelJugadorInvestigacion
                    .Where(w => w.id == idRel)
                    .SingleOrDefault();

            r.nivel += 1;
            ctx.SaveChangesAsync().Wait();

            relJMHandler.actualizarProduccionCapacidad(r.colonia.id);
        }

        public void bajarNivelI(int id)
        {
            try
            {
                var r = ctx.RelJugadorInvestigacion
                   .Where(w => w.id == id)
                   .SingleOrDefault();

                if (r != null)
                {
                    r.nivel -= 1;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RelJugadorInvestigacion getRelJugadorInvestigacion(int id)
        {
            var rel = ctx.RelJugadorInvestigacion.Where(w => w.id == id).FirstOrDefault();
            return rel.getShared();
        }
    }
}
