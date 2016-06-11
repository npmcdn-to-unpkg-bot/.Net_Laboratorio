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
    public class RelJugadorRecursoHandlerEF : IRelJugadorRecursoHandler
    {
        TenantContext ctx;
        public RelJugadorRecursoHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createRelJugadorRecurso(RelJugadorRecurso r)
        {
            var rec = ctx.Recurso.Where(w => w.id == r.recurso.id).SingleOrDefault();
            var col = ctx.RelJugadorMapa.Where(w => w.id == r.colonia.id).SingleOrDefault();

            var rjr = new Entities.RelJugadorRecurso(rec, col, r.capacidad, r.cantidadR, r.produccionXTiempo, r.ultimaConsulta);

            try
            {
                ctx.RelJugadorRecurso.Add(rjr);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteRelJugadorRecurso(int id)
        {
            var rjr = (from c in ctx.RelJugadorRecurso
                       where c.id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.RelJugadorRecurso.Remove(rjr);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RelJugadorRecurso getRelJugadorRecurso(int id)
        {
            try
            {
                var r = (from c in ctx.RelJugadorRecurso
                           where c.id == id
                           select c).SingleOrDefault();
                
                return r.getShared();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateRelJugadorRecurso(RelJugadorRecurso rS)
        {
            try
            {
                var r = ctx.RelJugadorRecurso
                    .Where(w => w.id == rS.id)
                    .SingleOrDefault();

                if (r != null)
                {
                    r.capacidad = rS.capacidad;
                    r.cantidadR = rS.cantidadR;
                    r.produccionXTiempo = rS.produccionXTiempo;
                    r.ultimaConsulta = rS.ultimaConsulta;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RelJugadorRecurso> getRecursosByColonia(int id)
        {
            calcularRecursosByIdCol(id);
            var recursos = new List<RelJugadorRecurso>();
            try
            {
                ctx.Database.Connection.Open();
                List<Entities.RelJugadorRecurso> recursosE = ctx.RelJugadorRecurso.Where(w => w.colonia.id == id).ToList();
                ctx.Database.Connection.Close();
                foreach (var item in recursosE)
                {
                    recursos.Add(item.getShared());
                }

                return recursos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void calcularRecursosByIdCol(int id)
        {
            List<Entities.RelJugadorRecurso> relJR = ctx.RelJugadorRecurso.Where(w => w.colonia.id == id).ToList();
            
            DateTime ahora = DateTime.Now;
            TimeSpan dif = ahora.Subtract(relJR.FirstOrDefault().ultimaConsulta);
            int segundos = Convert.ToInt32(dif.TotalSeconds);
            foreach (var rel in relJR)
            {
                int prod = Convert.ToInt32((rel.produccionXTiempo * segundos) / 3600);
                if ((prod + rel.cantidadR) >= rel.capacidad)
                {
                    rel.cantidadR = rel.capacidad;
                }
                else
                {
                    rel.cantidadR += prod;
                }
                rel.ultimaConsulta = ahora;
            }
       //     ctx.SaveChangesAsync().Wait();

        }

        public void restarCompra(int idColonia, List<Entities.Costo> gastos)
        {
            List<Entities.RelJugadorRecurso> recursos = ctx.RelJugadorRecurso.Where(w => w.colonia.id == idColonia).ToList();
            foreach (var g in gastos)
            {
                foreach (var r in recursos)
                {
                    if (g.recurso.id == r.recurso.id)
                    {
                        r.cantidadR -= g.valor;
                    }
                }
            }
            ctx.SaveChangesAsync().Wait();
        }
    }
}
