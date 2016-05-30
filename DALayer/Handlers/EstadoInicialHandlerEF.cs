using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Interfaces;
using SharedEntities.Entities;

namespace DALayer.Handlers
{
    public class EstadoInicialHandlerEF : IEstadoInicial
    {
        TenantContext ctx;

        public EstadoInicialHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createEstadoInicial(EstadoInicialJuego e)
        {
            try
            {
                var rec = ctx.Recurso
                    .Where(w => w.id == e.r.id)
                    .SingleOrDefault();
                Entities.EstadoInicialJuego eij = new Entities.EstadoInicialJuego(rec, e.cantidad);
                ctx.EstadoInicialJuego.Add(eij);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteEstadoInicial(int id)
        {
            var e = (from c in ctx.EstadoInicialJuego
                       where c.id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.EstadoInicialJuego.Remove(e);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EstadoInicialJuego> getAllEstados()
        {
            List<EstadoInicialJuego> estados = new List<EstadoInicialJuego>();
            try
            {
                ctx.Database.Connection.Open();
                List<Entities.EstadoInicialJuego> estE = ctx.EstadoInicialJuego.ToList();
                ctx.Database.Connection.Close();
                foreach (Entities.EstadoInicialJuego item in estE)
                {
                    Recurso rec = new Recurso(item.r.id, item.r.nombre, item.r.descripcion, item.r.foto);
                    EstadoInicialJuego e = new EstadoInicialJuego(item.id, rec, item.cantidad);
                    estados.Add(e);
                }

                return estados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EstadoInicialJuego getEstadoInicial(int id)
        {
            try
            {
                var eiE = ctx.EstadoInicialJuego
                    .Where(w => w.id == id).SingleOrDefault();

                var rec = new Recurso(eiE.r.id, eiE.r.nombre, eiE.r.descripcion, eiE.r.foto);
                EstadoInicialJuego estado = new EstadoInicialJuego(id, rec, eiE.cantidad);

                return estado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateEstadoInicial(EstadoInicialJuego eij)
        {
            try
            {
                var eiE = ctx.EstadoInicialJuego
                    .Where(w => w.id == eij.id).SingleOrDefault();
                var rec = ctx.Recurso
                    .Where(w => w.id == eij.r.id).SingleOrDefault();

                if (eiE != null)
                {
                    eiE.r = rec;
                    eiE.cantidad = eij.cantidad;

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
