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
    public class RelJugadorDestacamentoHandlerEF : IRelJugadorDestacamentoHandler
    {
        TenantContext ctx;
        public RelJugadorDestacamentoHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createRelJugadorDestacamento(RelJugadorDestacamento r)
        {
            CostoHandlerEF cosoH = new CostoHandlerEF(ctx);
            var col = ctx.RelJugadorMapa.Where(w => w.id == r.colonia.id).SingleOrDefault();
            var des = ctx.Destacamento.Where(w => w.id == r.destacamento.id).SingleOrDefault();

            List<Entities.Costo> cos = new List<Entities.Costo>();
            foreach (var item in r.destacamento.costos)
            {
                var rec = ctx.Recurso.Where(w => w.id == item.recurso.id).SingleOrDefault();
                var prod = ctx.Producto.Where(w => w.id == item.idProducto).SingleOrDefault();
                var c = new Entities.Costo(rec, prod, item.valor, item.incrementoNivel);
                cos.Add(c);
            }
            List<Entities.Capacidad> cap = new List<Entities.Capacidad>();
            foreach (var item in r.destacamento.capacidad)
            {
                var rec = ctx.Recurso.Where(w => w.id == item.recurso.id).SingleOrDefault();
                var prod = ctx.Producto.Where(w => w.id == item.idProducto).SingleOrDefault();
                var c = new Entities.Capacidad(rec, prod, item.valor, item.incrementoNivel);
                cap.Add(c);
            }

            var rje = new Entities.RelJugadorDestacamento(col, des, r.cantidad, r.finalizaConstruccion);

            try
            {
                ctx.RelJugadorDestacamento.Add(rje);

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public RelJugadorDestacamento getRelJugadorDestacamento(int id)
        {
            try
            {
                var rjd = (from c in ctx.RelJugadorDestacamento
                           where c.id == id
                           select c).SingleOrDefault();

                return rjd.getShared();
                }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean updateRelJugadorDestacamento(RelJugadorDestacamento rje)
        {
            RelJugadorRecursoHandlerEF jrHandler = new RelJugadorRecursoHandlerEF(ctx);
            var relJMHandler = new RelJugadorMapaHandlerEF(ctx);
            try
            {
                var r = ctx.RelJugadorDestacamento
                    .Where(w => w.id == rje.id)
                    .SingleOrDefault();

                if (r != null)
                {
                    var dest = r.getShared();
                    var cant = rje.cantidad - r.cantidad;
                    if (!rje.getForceUpdate())
                    {
                        List<Entities.Costo> costos = r.destacamento.calCostoXNivel(0, cant);
                        Boolean compro = jrHandler.restarCompra(r.colonia.id, costos);
                        if (compro == false)
                        {
                            return false;
                        }
                        DateTime ahora = DateTime.Now;
                        TimeSpan tConstruccion = TimeSpan.FromSeconds(dest.destacamento.tiempoInicial * cant);
                        r.finalizaConstruccion = ahora.Add(tConstruccion);
                    }
                    else {
                        r.cantidad = rje.cantidad;
                    }
                     
                    ctx.SaveChangesAsync().Wait();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void executeUpdateRelJD (RelJugadorDestacamento rel)
        {
            var relJMHandler = new RelJugadorMapaHandlerEF(ctx);
            var r = ctx.RelJugadorDestacamento
                    .Where(w => w.id == rel.id)
                    .SingleOrDefault();

            r.cantidad += rel.cantidad;
            ctx.SaveChangesAsync().Wait();
            relJMHandler.actualizarProduccionCapacidad(r.colonia.id);
        }

        public List<RelJugadorDestacamento> getDestacamentosByColonia(int id)
        {
            var destacamentos = new List<RelJugadorDestacamento>();
            try
            {
                ctx.Database.Connection.Open();
                List<Entities.RelJugadorDestacamento> destacamentosD = ctx.RelJugadorDestacamento.Where(w => w.colonia.id == id).ToList();
                ctx.Database.Connection.Close();
                foreach (var item in destacamentosD)
                {
                    destacamentos.Add(item.getShared());
                }

                return destacamentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void subirCantidadDestacamento(int id, int sube)
        {
            RelJugadorRecursoHandlerEF jrHandler = new RelJugadorRecursoHandlerEF(ctx);
            var relJMHandler = new RelJugadorMapaHandlerEF(ctx);
            try
            {
                var r = ctx.RelJugadorDestacamento
                    .Where(w => w.id == id)
                    .SingleOrDefault();

                if (r != null)
                {
                    var dest = r.getShared();
                    DateTime ahora = DateTime.Now;
                    TimeSpan tConstruccion = TimeSpan.FromMinutes(dest.destacamento.tiempoInicial * sube);
                    r.finalizaConstruccion = ahora.Add(tConstruccion);

                    List<Entities.Costo> costos = r.destacamento.calCostoXNivel(0, sube);
                    jrHandler.restarCompra(r.colonia.id, costos);
                    r.cantidad += sube;
                    ctx.SaveChangesAsync().Wait();

                    relJMHandler.actualizarProduccionCapacidad(r.colonia.id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void bajarCantidadDestacamento(int id, int baja)
        {
            try
            {
                var r = ctx.RelJugadorDestacamento
                   .Where(w => w.id == id)
                   .SingleOrDefault();

                if (r != null)
                {
                    r.cantidad -= baja;
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
