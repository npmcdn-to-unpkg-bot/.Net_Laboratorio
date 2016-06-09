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
            var prod = ctx.Producto.Where(w => w.id == c.idProducto).SingleOrDefault();
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
            try
            {
                var cost = (from c in ctx.Costo
                           where c.Id == id
                           select c).SingleOrDefault();
                
                return cost.getShared();
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
                    var prod = ctx.Producto.Where(w => w.id == cost.idProducto).SingleOrDefault();
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

