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
    public class InvestigacionHandlerEF : IInvestigacionHandler
    {
        TenantContext ctx;
        public InvestigacionHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public int createInvestigacion(Investigacion i)
        {
            var inv = new Entities.Investigacion(i.nombre, i.descripcion, i.foto);
            
            try
            {
                ctx.Investigacion.Add(inv);
                ctx.SaveChanges();

                Entities.Investigacion invs = ctx.Investigacion.ToList().LastOrDefault();

                return invs.id;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public void deleteInvestigacion(int id)
        {
            var inv = (from c in ctx.Investigacion
                       where c.id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.Investigacion.Remove(inv);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Investigacion> getAllInvestigaciones()
        {
            var investigacionesS = new List<Investigacion>();
            try
            {
                var investigacionesE = ctx.Investigacion.ToList();
                foreach (var i in investigacionesE)
                {
                    investigacionesS.Add(i.getShared());
                }
                return investigacionesS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Investigacion getInvestigacion(int id)
        {
            CostoHandlerEF costoHandler = new CostoHandlerEF(ctx);
            try
            {
                var inv = (from c in ctx.Investigacion
                           where c.id == id
                           select c).SingleOrDefault();
                
                return inv.getShared();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateInvestigacion (Investigacion inv)
        {
            try
            {
                var invTmp = ctx.Investigacion
                    .Where(w => w.id == inv.id)
                    .SingleOrDefault();

                if (invTmp != null)
                {
                    var costos = new List<Entities.Costo>();
                    foreach (var c in invTmp.getCosto())
                    {
                        costos.Add(c);
                    }
                    invTmp.nombre = inv.nombre;
                    invTmp.descripcion = inv.descripcion;
                    invTmp.foto = inv.foto;
                    invTmp.costos = costos;
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
