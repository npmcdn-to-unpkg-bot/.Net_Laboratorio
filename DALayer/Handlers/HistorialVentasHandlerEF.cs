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

            hv.id = hvTmp.id;
            hv.idusuario = hvTmp.idusuario;
            hv.nombreOferta = hvTmp.nombreOferta;
            hv.fechaCompra = hvTmp.fechaCompra;

            ctx.HistorialVentas.Add(hv);
            try
            {

                ctx.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        public void deleteHistorialVentas(Guid idTmp)
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


    }
}
