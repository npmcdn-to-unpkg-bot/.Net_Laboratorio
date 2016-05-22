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
        public void createInvestigacion(Investigacion invTmp)
        {
            Entities.Investigacion inv = new Entities.Investigacion();
            
            inv.nombre = invTmp.nombre;
            inv.descripcion = invTmp.descripcion;
            inv.foto = invTmp.foto;
            inv.costo = invTmp.costo;
            inv.factorCostoNivel = invTmp.factorCostoNivel;
            inv.nivel = invTmp.nivel;
            
            try
            {
                ctx.Investigacion.Add(inv);

                ctx.SaveChanges();
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
            List<Investigacion> invest = new List<Investigacion>();
            try
            {
                List<Entities.Investigacion> invTmp = ctx.Investigacion.ToList();
                foreach (Entities.Investigacion item in invTmp)
                {
                    Investigacion inv = new Investigacion(item.id, item.nombre, item.descripcion, item.foto, item.costo, item.factorCostoNivel, item.nivel);
                    invest.Add(inv);
                }
                return invest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Investigacion getInvestigacion(int id)
        {
            throw new NotImplementedException();
        }

        public void updateInvestigacion (Investigacion inv)
        {
            try
            {
                var invTmp = ctx.Investigacion
                    .Where(w => w.nombre == inv.nombre)
                    .SingleOrDefault();

                if (invTmp != null)
                {
                    invTmp.descripcion = inv.descripcion;
                    invTmp.foto = inv.foto;
                    invTmp.factorCostoNivel = inv.factorCostoNivel;
                    invTmp.costo = inv.costo;
                    invTmp.nivel = inv.nivel;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void getInvestigacionByUser()
        {
            throw new NotImplementedException();
        }

        void updateInvestigacionByUser()
        {
            throw new NotImplementedException();
        }
    }
}
