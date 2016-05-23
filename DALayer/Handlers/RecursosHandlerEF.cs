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
            try
            {
                ctx.Recurso.Add(rec);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void deleteRecurso(int id)
        {
            var rec = (from c in ctx.Recurso
                        where c.id == id
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
                    Recurso rec = new Recurso(item.id, item.nombre, item.descripcion, item.foto);
                    recursos.Add(rec);
                }

                return recursos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Recurso getRecurso(int id)
        {
            try
            {
                var rec = (from c in ctx.Recurso
                           where c.id == id
                           select c).SingleOrDefault();

                Recurso recurso = new Recurso(rec.id, rec.nombre, rec.descripcion, rec.foto);
                return recurso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateRecurso(Recurso rec)
        {
            try
            {
                var recT = ctx.Recurso
                    .Where(w => w.id == rec.id)
                    .SingleOrDefault();

                if (recT != null)
                {
                    recT.nombre = rec.nombre;
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

        public void getRecursoByUser()
        {
            throw new NotImplementedException();
        }

        public void updateRecursoByUser()
        {
            throw new NotImplementedException();
        }
    }
}
