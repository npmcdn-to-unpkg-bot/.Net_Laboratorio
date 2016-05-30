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

            public void createDependencia(Dependencia d)
            {
                var padre = (from c in ctx.Producto
                            where c.id == d.padreId
                            select c).SingleOrDefault();
                var hijo = (from c in ctx.Producto
                             where c.id == d.hijoId
                            select c).SingleOrDefault();

                Entities.Dependencia dep = new Entities.Dependencia(padre, hijo, d.nivel);

                try
                {
                    ctx.Dependencia.Add(dep);
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }

            }

            public void deleteDependencia(int id)
            {
                var dep = (from c in ctx.Dependencia
                           where c.id == id
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
                List<Dependencia> dependencias = new List<Dependencia>();
                try
                {
                    List<Entities.Dependencia> dependenciasTmp = ctx.Dependencia.ToList();
                    foreach (Entities.Dependencia item in dependenciasTmp)
                    {
                        Dependencia dep = getDependencia(item.id);
                        dependencias.Add(dep);
                    }
                    return dependencias;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
        }

        public Dependencia getDependencia(int id)
        {
            try
            {
                var d = (from c in ctx.Dependencia
                           where c.id == id
                           select c).SingleOrDefault();


                Dependencia dependencia = new Dependencia(d.id, prodEntToSha(d.padre), d.padre.id, prodEntToSha(d.hijo), d.hijo.id, d.nivel);
                return dependencia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateDependencia(Dependencia dep)
        {
            try
            {
                var depTmp = ctx.Dependencia
                    .Where(w => w.id == dep.id)
                    .SingleOrDefault();
                var padre = ctx.Producto
                    .Where(w => w.id == dep.padreId)
                    .SingleOrDefault();
                var hijo = ctx.Producto
                    .Where(w => w.id == dep.hijoId)
                    .SingleOrDefault();

                if (depTmp != null)
                {
                    depTmp.padre = padre;
                    depTmp.hijo = hijo;
                    depTmp.nivel = dep.nivel;

                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Dependencia> getDependenciasByProdId(int id)
        {
            var dependencias = new List<Dependencia>();
            try
            {
                ctx.Database.Connection.Open();
                List<Entities.Dependencia> depE = ctx.Dependencia.Where(w => w.padre.id == id).ToList();
                ctx.Database.Connection.Close();
                foreach (var item in depE)
                {
                    var rel = getDependencia(item.id);
                    dependencias.Add(rel);
                }

                return dependencias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Producto> getAllProductos()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                List<Entities.Producto> prodE = ctx.Producto.ToList();
                foreach (Entities.Producto item in prodE)
                {
                    Producto prod = prodEntToSha(item);
                    productos.Add(prod);
                }
                return productos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        Producto prodEntToSha(Entities.Producto p)
        {
                UnidadHandlerEF uHandler = new UnidadHandlerEF(ctx);
            InvestigacionHandlerEF iHandler = new InvestigacionHandlerEF(ctx);
            Producto prod;
            if (p is Entities.Edificio)
            {
                prod = uHandler.getEdificio(p.id);
            }
            else if (p is Entities.Destacamento)
            {
                prod = uHandler.getDestacamento(p.id);
            }
            else
            {
                prod = iHandler.getInvestigacion(p.id);
            }

            return prod;
        }
    }    
}
