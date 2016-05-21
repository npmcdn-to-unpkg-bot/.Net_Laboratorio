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
    public class PaquetePaypalHandlerEF : IPaquetePayPalHandler
    {

        TenantContext ctx;
        public PaquetePaypalHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createPaquetePaypal(PaquetePaypal ppTmp)
        {

            Entities.PaquetePaypal pp = new Entities.PaquetePaypal();
            pp.nombreOferta = ppTmp.nombreOferta;
            pp.producto = ppTmp.producto;
            pp.cantidad = ppTmp.cantidad;
            pp.precio = ppTmp.precio;
            pp.ofertaActiva = ppTmp.ofertaActiva;

            
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

        public void deletePaquetePaypal(string nombreOfertaTmp)
        {
            {
                var pp = (from c in ctx.PaquetePaypal
                           where c.nombreOferta == nombreOfertaTmp
                           select c).SingleOrDefault();
                try
                {
                    ctx.PaquetePaypal.Remove(pp);
                    ctx.SaveChangesAsync().Wait();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<PaquetePaypal> getAllPaquetes()
        {
            List<PaquetePaypal> paquetes = new List<PaquetePaypal>();
            try
            {
                List<Entities.PaquetePaypal> paquetesTmp = ctx.PaquetePaypal.ToList();
                foreach (Entities.PaquetePaypal item in paquetesTmp)
                {
                    PaquetePaypal pp = new PaquetePaypal(item.nombreOferta, item.producto, item.cantidad, item.precio, item.ofertaActiva);
                    paquetes.Add(pp);
                }
                return paquetes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updatePaquetePaypal(PaquetePaypal pp)
        {
            try
            {
                var ppTmp = ctx.PaquetePaypal
                    .Where(w => w.nombreOferta == pp.nombreOferta)
                    .SingleOrDefault();

                if (ppTmp != null)
                {
                    ppTmp.producto = pp.producto;
                    ppTmp.cantidad = pp.cantidad;
                    ppTmp.precio = pp.precio;
                    ppTmp.ofertaActiva = pp.ofertaActiva;

                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updatePaquetePaypalByUser()
        {
            throw new NotImplementedException();
        }

        public void getPaquetePaypalByUser()
        {
            throw new NotImplementedException();
        }
    }
}
