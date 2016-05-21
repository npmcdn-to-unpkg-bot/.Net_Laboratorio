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
    public class DependenciaHandlerEF : IDependenciaHandler
    {

            TenantContext ctx;
            public DependenciaHandlerEF(TenantContext tc)
            {
                ctx = tc;
            }
            public void createDependencia(Dependencia depTmp)
            {

                Entities.Dependencia dep = new Entities.Dependencia();
                dep.nombre = depTmp.nombre;
                dep.level = depTmp.level;
                //cambiar lo de shared
                //dep.dependencias = depTmp.dependencias;

                ctx.Dependencia.Add(dep);
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

            public void deleteDependencia(string nombreTmp)
            {
                var dep = (from c in ctx.Dependencia
                           where c.nombre == nombreTmp
                           select c).SingleOrDefault();
                try
                {
                    ctx.Dependencia.Remove(dep);
                    ctx.SaveChangesAsync().Wait();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public List<Dependencia> getAllDependencias()
            {
            //List<Dependencia> dependencias = new List<Dependencia>();
            //try
            //{
            //    List<Entities.Dependencia> dependenciasTmp = ctx.Dependencia.ToList();
            //    foreach (Entities.Dependencia item in dependenciasTmp)
            //    {
            //        Dependencia dep = new Dependencia(item.nombre, item.level, item.dependencias);
            //        dependencias.Add(dep);
            //    }
            //    return dependencias;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            throw new NotImplementedException();
            }

            public void getDependenciaByUser()
            {
                throw new NotImplementedException();
            }

            public void updateDependencia(Dependencia dep)
            {
                try
                {
                    var depTmp = ctx.Dependencia
                        .Where(w => w.nombre == dep.nombre)
                        .SingleOrDefault();

                    if (depTmp != null)
                    {
                        dep.nombre = depTmp.nombre;
                        dep.level = depTmp.level;
                        depTmp.dependencias = depTmp.dependencias;
                        ctx.SaveChangesAsync().Wait();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            public void updateDependenciaByUser()
            {
                throw new NotImplementedException();
            }
        }    
}
