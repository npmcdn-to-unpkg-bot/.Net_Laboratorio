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
        public void CreateRecurso(Recurso recTmp)
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

        public void DeleteRecurso(int id)
        {
            throw new NotImplementedException();
        }

        public List<Recurso> GetAllRecursos()
        {
            throw new NotImplementedException();
        }

        public void GetRecursoByUser()
        {
            throw new NotImplementedException();
        }

        public void UpdateRecurso(Recurso emp)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecursoByUser()
        {
            throw new NotImplementedException();
        }
    }
}
