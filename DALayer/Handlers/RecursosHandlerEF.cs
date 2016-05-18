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
    public class RecursosHandlerEF : IRecursoHandler
    {
        TenantContext ctx;
        public RecursosHandlerEF(TenantContext tc) {
            ctx = tc;
        }
        public void createRecurso(Recurso recTmp)
        {

            Entities.Recurso rec = new Entities.Recurso();
            rec.descripcion = recTmp.descripcion;
            rec.foto = recTmp.foto;
            rec.nombre = recTmp.nombre;

            ctx.Recurso.Add(rec);
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

        public void deleteRecurso(string nombreTmp)
        {
            var rec = (from c in ctx.Recurso
                                    where c.nombre == nombreTmp
                                    select c).SingleOrDefault();
            try
            {
                ctx.Recurso.Remove(rec);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Recurso> getAllRecursos()
        {
            List<Recurso> recursos = new List<Recurso>();
            try
            {
                List<Entities.Recurso> recursosTmp = ctx.Recurso.ToList();
                foreach (Entities.Recurso item in recursosTmp)
                {
                    Recurso rec = new Recurso(item.nombre, item.descripcion, item.foto);
                    recursos.Add(rec);
                }
                return recursos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void getRecursoByUser()
        {
            throw new NotImplementedException();
        }

        public void updateRecurso(Recurso rec)
        {
            try
            {
                var recT = ctx.Recurso
                    .Where(w => w.nombre == rec.nombre)
                    .SingleOrDefault();

                if (recT != null)
                {
                    recT.descripcion = rec.descripcion;
                    recT.foto = rec.foto;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateRecursoByUser()
        {
            throw new NotImplementedException();
        }
    }
}
