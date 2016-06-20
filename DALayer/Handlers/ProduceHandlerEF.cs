using DALayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Handlers
{
    public class ProduceHandlerEF : IProduceHandler
    {
        TenantContext ctx;
        public ProduceHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createProduce(Produce p)
        {
            try
            {
                ctx.Database.Connection.Open();
                Entities.Recurso rec = ctx.Recurso.Where(w => w.id == p.recurso.id).SingleOrDefault();
                var prod = ctx.Producto.Where(w => w.id == p.idProducto).SingleOrDefault();
                var produce = new Entities.Produce(rec, prod, p.valor, p.incrementoNivel);
                ctx.Produce.Add(produce);
                ctx.SaveChanges();
                ctx.Database.Connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteProduce(int id)
        {
            var produce = (from c in ctx.Produce
                        where c.Id == id
                        select c).SingleOrDefault();
            try
            {
                ctx.Produce.Remove(produce);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produce getProduce(int id)
        {
            try
            {
                var produce = (from c in ctx.Produce
                            where c.Id == id
                            select c).SingleOrDefault();

                return produce.getShared();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateProduce(Produce p)
        {
            try
            {
                var produce = ctx.Produce
                    .Where(w => w.Id == p.Id)
                    .SingleOrDefault();

                if (produce != null)
                {
                    var rec = ctx.Recurso.Where(w => w.id == p.recurso.id).SingleOrDefault();
                    var prod = ctx.Producto.Where(w => w.id == p.idProducto).SingleOrDefault();
                    produce.recurso = rec;
                    produce.producto = prod;
                    produce.valor = p.valor;
                    produce.incrementoNivel = p.incrementoNivel;

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
