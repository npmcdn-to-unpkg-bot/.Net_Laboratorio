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
    public class CostoHandlerEF : ICostoHandler
    {
        TenantContext ctx;
        public CostoHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

    public void createCosto(Costo c)
    {
        Entities.Recurso rec = new Entities.Recurso(c.recurso.nombre, c.recurso.descripcion, c.recurso.cantInicial, c.recurso.foto);
        var cost = new Entities.Costo(c.Id, rec, c.valor, c.incrementoNivel);

        try
        {
            ctx.Costo.Add(cost);

            ctx.SaveChanges();
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public void deleteCosto(int id)
    {
        var cost = (from c in ctx.Costo
                   where c.Id == id
                   select c).SingleOrDefault();
        try
        {
            ctx.Costo.Remove(cost);
            ctx.SaveChangesAsync().Wait();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<Costo> getAllCostos()
    {
        var costosShared = new List<Costo>();
        try
        {
            var costosEntities = ctx.Costo.ToList();
            foreach (var c in costosEntities)
            {
                    Recurso rec = new Recurso(c.recurso.id, c.recurso.nombre, c.recurso.descripcion, c.recurso.cantInicial, c.recurso.foto);
                var cost = new Costo(rec,c.valor, c.incrementoNivel);
                costosShared.Add(cost);
            }
            return costosShared;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Costo getCosto(int id)
    {
        try
        {
            var cost = (from c in ctx.Costo
                       where c.Id == id
                       select c).SingleOrDefault();

                Recurso rec = new Recurso(cost.recurso.id, cost.recurso.nombre, cost.recurso.descripcion, cost.recurso.cantInicial, 
                                          cost.recurso.foto);
            Costo costo = new Costo(rec, cost.valor, cost.incrementoNivel);
            return costo;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void updateCosto(Costo cost)
    {
        try
        {
            var costTmp = ctx.Costo
                .Where(w => w.Id == cost.Id)
                .SingleOrDefault();

            if (costTmp != null)
            {
                Entities.Recurso rec = new Entities.Recurso(cost.recurso.nombre, cost.recurso.descripcion, cost.recurso.cantInicial,
                                          cost.recurso.foto);
                costTmp.recurso = rec;
                costTmp.valor = cost.valor;
                costTmp.incrementoNivel = cost.incrementoNivel;

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

