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
    public class InvestigacionHandlerEF : IInvestigacionHandler
    {
        TenantContext ctx;
        public InvestigacionHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createInvestigacion(Investigacion i)
        {
            List<Entities.Costo> cos = new List<Entities.Costo>();
            foreach (var item in i.costos)
            {
                var c = new Entities.Costo(item.idRecurso, item.valor, item.incrementoNivel);
                cos.Add(c);
            }

            var inv = new Entities.Investigacion(i.nombre, i.descripcion, i.foto, cos, i.factorCostoNivel);
            
            try
            {
                ctx.Investigacion.Add(inv);

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public void deleteInvestigacion(int id)
        {
            var inv = (from c in ctx.Investigacion
                       where c.id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.Investigacion.Remove(inv);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Investigacion> getAllInvestigaciones()
        {
            var investigacionesS = new List<Investigacion>();
            try
            {
                var investigacionesE = ctx.Investigacion.ToList();
                foreach (var i in investigacionesE)
                {
                    var costos = new List<Costo>();
                    foreach (var c in i.getCosto())
                    {
                        var cos = new Costo(c.idRecurso, c.valor, c.incrementoNivel);
                        costos.Add(cos);
                    }
                    var inv = new Investigacion(i.id, i.nombre, i.descripcion, i.foto, costos, i.factorCostoNivel);
                    investigacionesS.Add(inv);
                }
                return investigacionesS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Investigacion getInvestigacion(int id)
        {
            try
            {
                var inv = (from c in ctx.Investigacion
                           where c.id == id
                           select c).SingleOrDefault();

                var costos = new List<Costo>();
                foreach (var c in inv.getCosto())
                {
                    var cos = new Costo(c.idRecurso, c.valor, c.incrementoNivel);
                    costos.Add(cos);
                }
                Investigacion investigacion = new Investigacion(inv.id, inv.nombre, inv.descripcion, inv.foto, costos, inv.factorCostoNivel);
                return investigacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateInvestigacion (Investigacion inv)
        {
            try
            {
                var invTmp = ctx.Investigacion
                    .Where(w => w.id == inv.id)
                    .SingleOrDefault();

                if (invTmp != null)
                {
                    var costos = new List<Entities.Costo>();
                    foreach (var c in invTmp.getCosto())
                    {
                        var cos = new Entities.Costo(c.idRecurso, c.valor, c.incrementoNivel);
                        costos.Add(cos);
                    }
                    invTmp.nombre = inv.nombre;
                    invTmp.descripcion = inv.descripcion;
                    invTmp.foto = inv.foto;
                    invTmp.factorCostoNivel = inv.factorCostoNivel;
                    invTmp.costos = costos;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void getInvestigacionByUser()
        {
            throw new NotImplementedException();
        }

        void updateInvestigacionByUser()
        {
            throw new NotImplementedException();
        }
    }
}
