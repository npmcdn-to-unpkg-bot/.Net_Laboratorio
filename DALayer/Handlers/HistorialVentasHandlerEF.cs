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
    public class HistorialVentasHandlerEF : IHistorialVentasHandler
    {
        TenantContext ctx;
        public HistorialVentasHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }
        public void createHistorialVentas(HistorialVentas hvTmp)
        {

            Entities.HistorialVentas hv = new Entities.HistorialVentas();
            
            hv.idusuario = hvTmp.idusuario;
            hv.nombreOferta = hvTmp.nombreOferta;
            hv.fechaCompra = hvTmp.fechaCompra;

            try
            {
                ctx.HistorialVentas.Add(hv);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void deleteHistorialVentas(int idTmp)
        {
            var hv = (from c in ctx.HistorialVentas
                       where c.id == idTmp
                       select c).SingleOrDefault();
            try
            {
                ctx.HistorialVentas.Remove(hv);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HistorialVentas> getAllHistorialesVenta()
        {
            List<HistorialVentas> historiales = new List<HistorialVentas>();
            try
            {
                List<Entities.HistorialVentas> historialesTmp = ctx.HistorialVentas.ToList();
                foreach (Entities.HistorialVentas item in historialesTmp)
                {
                    HistorialVentas hv = new HistorialVentas(item.id, item.idusuario, item.nombreOferta, item.fechaCompra);
                    historiales.Add(hv);
                }
                return historiales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateHistorialVentas(HistorialVentas hv)
        {
            try
            {
                var hvTemp = ctx.HistorialVentas
                    .Where(w => w.id == hv.id)
                    .SingleOrDefault();

                if (hvTemp != null)
                {
                    hvTemp.idusuario = hv.idusuario;
                    hvTemp.nombreOferta = hv.nombreOferta;
                    hvTemp.fechaCompra = hv.fechaCompra;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void getHistorialVentasByUser()
        {
            throw new NotImplementedException();
        }

        public void updateHistorialVentasByUser()
        {
            throw new NotImplementedException();
        }

        public HistorialVentas getHistorialVentas(int id)
        {
            throw new NotImplementedException();
        }
    }
}
