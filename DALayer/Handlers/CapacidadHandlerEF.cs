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
    public class CapacidadHandlerEF : ICapacidadHandler
    {
        TenantContext ctx;
        public CapacidadHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createCapacidad(Capacidad c)
        {
            var recurso = ctx.Recurso.Where(w => w.id == c.recurso.id).SingleOrDefault();
            var producto = ctx.Producto.Where(w => w.id == c.idProducto).SingleOrDefault();
            var capacity = new Entities.Capacidad(recurso, producto, c.valor, c.incrementoNivel);

            try
            {
                ctx.Capacidad.Add(capacity);

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteCapacidad(int id)
        {
            var capacity = (from c in ctx.Capacidad
                        where c.Id == id
                        select c).SingleOrDefault();
            try
            {
                ctx.Capacidad.Remove(capacity);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Capacidad getCapacidad(int id)
        {
            try
            {
                var c = (from cap in ctx.Capacidad
                            where cap.Id == id
                            select cap).SingleOrDefault();

                return c.getShared();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateCapacidad(Capacidad capacity)
        {
            try
            {
                var capacityTmp = ctx.Capacidad
                    .Where(w => w.Id == capacity.Id)
                    .SingleOrDefault();

                if (capacityTmp != null)
                {
                    var rec = ctx.Recurso.Where(w => w.id == capacityTmp.recurso.id).SingleOrDefault();
                    var prod = ctx.Producto.Where(w => w.id == capacityTmp.producto.id).SingleOrDefault();
                    capacityTmp.recurso = rec;
                    capacityTmp.producto = prod;
                    capacityTmp.valor = capacity.valor;
                    capacityTmp.incrementoNivel = capacity.incrementoNivel;

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
