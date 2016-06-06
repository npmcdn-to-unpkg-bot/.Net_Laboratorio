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
    public class CostoHandlerEF : ICostoHandler
    {
        TenantContext ctx;
        public CostoHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createCosto(Costo c)
        {
            Entities.Recurso rec = ctx.Recurso.Where(w => w.id == c.recurso.id).SingleOrDefault();
            var prod = ctx.Producto.Where(w => w.id == c.producto.id).SingleOrDefault();
            var cost = new Entities.Costo(rec, prod, c.valor, c.incrementoNivel);

            try
            {
                ctx.Costo.Add(cost);

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteCosto(int id)
        {
            var cost = (from c in ctx.Costo
                       where c.Id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.Costo.Remove(cost);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Costo getCosto(int id)
        {
            RecursosHandlerEF recHandler = new RecursosHandlerEF(ctx);
            DependenciaHandlerEF depHandler = new DependenciaHandlerEF(ctx);
            try
            {
                var cost = (from c in ctx.Costo
                           where c.Id == id
                           select c).SingleOrDefault();

                var rec = recHandler.getRecurso(cost.recurso.id);
                var prod = ctx.Producto.Where(w => w.id == cost.producto.id).SingleOrDefault();
                Costo costo = new Costo(cost.Id, rec, depHandler.prodEntToSha(prod), prod.id, cost.valor, cost.incrementoNivel);
                return costo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateCosto(Costo cost)
        {
            try
            {
                var costTmp = ctx.Costo
                    .Where(w => w.Id == cost.Id)
                    .SingleOrDefault();

                if (costTmp != null)
                {
                    var rec = ctx.Recurso.Where(w => w.id == cost.recurso.id).SingleOrDefault();
                    var prod = ctx.Producto.Where(w => w.id == cost.producto.id).SingleOrDefault();
                    costTmp.recurso = rec;
                    costTmp.producto = prod;
                    costTmp.valor = cost.valor;
                    costTmp.incrementoNivel = cost.incrementoNivel;

                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

