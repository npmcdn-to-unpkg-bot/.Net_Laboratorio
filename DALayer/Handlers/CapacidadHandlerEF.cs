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
            Entities.Recurso rec = new Entities.Recurso(c.recurso.nombre, c.recurso.descripcion, c.recurso.cantInicial, c.recurso.foto);
            var capacity = new Entities.Capacidad(c.Id, rec, c.valor, c.incrementoNivel);

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

        public List<Capacidad> getAllCapacidades()
        {
            var capacidadShared = new List<Capacidad>();
            try
            {
                var capacidadEntities = ctx.Capacidad.ToList();
                foreach (var c in capacidadEntities)
                {
                    Recurso rec = new Recurso(c.recurso.id, c.recurso.nombre, c.recurso.descripcion, c.recurso.cantInicial, c.recurso.foto);
                    var capacity = new Capacidad(rec, c.valor, c.incrementoNivel);
                    capacidadShared.Add(capacity);
                }
                return capacidadShared;
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
                var capacity = (from c in ctx.Capacidad
                            where c.Id == id
                            select c).SingleOrDefault();

                Recurso rec = new Recurso(capacity.recurso.id, capacity.recurso.nombre, capacity.recurso.descripcion, capacity.recurso.cantInicial,
                                          capacity.recurso.foto);
                Capacidad capacidad = new Capacidad(rec, capacity.valor, capacity.incrementoNivel);
                return capacidad;
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
                    Entities.Recurso rec = new Entities.Recurso(capacity.recurso.nombre, capacity.recurso.descripcion, capacity.recurso.cantInicial,
                                              capacity.recurso.foto);
                    capacityTmp.recurso = rec;
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
