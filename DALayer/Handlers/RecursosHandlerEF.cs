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

        public void createRecurso(Recurso r)
        {
            Entities.Recurso rec = new Entities.Recurso(r.nombre, r.descripcion, r.cantInicial, r.capacidadInicial, r.produccionXTiempo, r.foto);
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
                ctx.Database.Connection.Open();
                List<Entities.Recurso> recursosTmp = ctx.Recurso.ToList();
                ctx.Database.Connection.Close();
                foreach (Entities.Recurso item in recursosTmp)
                {
                    recursos.Add(item.getShared());
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
                
                return rec.getShared();
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
                    recT.cantInicial = rec.cantInicial;
                    recT.capacidadInicial = rec.capacidadInicial;
                    recT.produccionXTiempo = rec.produccionXTiempo;
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
