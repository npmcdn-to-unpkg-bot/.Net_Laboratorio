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
    public class FlotaHandlerEF : IFlotaHandler
    {
        TenantContext ctx;
        public FlotaHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }
        public void CreateFlota(Flota fleetTmp)
        {

            Entities.Flota fleet = new Entities.Flota();
            fleet.cantidad = fleetTmp.cantidad;
            fleet.typoNave = fleetTmp.typoNave;             

            
            try
            {
                ctx.Flota.Add(fleet);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void DeleteFlota(int idTmp)
        {
            var fleet = (from c in ctx.Flota
                         where c.id == idTmp
                         select c).SingleOrDefault();
            try
            {
                ctx.Flota.Remove(fleet);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Flota> GetAllFlotas()
        {
            List<Flota> fleetList = new List<Flota>();
            try
            {
                List<Entities.Flota> fleetTmp = ctx.Flota.ToList();
                foreach (Entities.Flota item in fleetTmp)
                {
                    Flota flot = new Flota(item.id, item.typoNave, item.cantidad);
                    fleetList.Add(flot);
                }
                return fleetList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateFlota(Flota fleet)
        {
            try
            {
                var fleetTmp = ctx.Flota
                    .Where(w => w.id == fleet.id)
                    .SingleOrDefault();

                if (fleetTmp != null)
                {
                    fleetTmp.typoNave = fleet.typoNave;
                    fleetTmp.cantidad = fleet.cantidad;

                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetFlotaByUser()
        {
            throw new NotImplementedException();
        }

        public void UpdateFlotaByUser()
        {
            throw new NotImplementedException();
        }

        public Flota getFlota(int id)
        {
            throw new NotImplementedException();
        }
    }
}
