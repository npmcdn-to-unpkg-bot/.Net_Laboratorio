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
    public class RelJugadorInvestigacionHandlerEF : IRelJugadorInvestigacionHandler
    {
        TenantContext ctx;
        public RelJugadorInvestigacionHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createRelJugadorInvestigacion(RelJugadorInvestigacion r)
        {
            var col = ctx.RelJugadorMapa.Where(w => w.id == r.colonia.id).SingleOrDefault();
            var inv = ctx.Investigacion.Where(w => w.id == r.investigacion.id).SingleOrDefault();

            List<Entities.Costo> cos = new List<Entities.Costo>();
            foreach (var item in r.investigacion.costos)
            {
                var rec = ctx.Recurso.Where(w => w.id == item.recurso.id).SingleOrDefault();
                var prod = ctx.Producto.Where(w => w.id == item.idProducto).SingleOrDefault();
                var c = new Entities.Costo(rec, prod, item.valor, item.incrementoNivel);
                cos.Add(c);
            }

            Entities.RelJugadorInvestigacion rji = new Entities.RelJugadorInvestigacion(col, inv, r.nivel);
            
            try
            {
                ctx.RelJugadorInvestigacion.Add(rji);

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteRelJugadorInvestigacion(int id)
        {
            var rji = (from c in ctx.RelJugadorInvestigacion
                       where c.id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.RelJugadorInvestigacion.Remove(rji);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateRelJugadorInvestigacion(RelJugadorInvestigacion rji)
        {
            try
            {
                var rjiTmp = ctx.RelJugadorInvestigacion
                    .Where(w => w.id == rji.id)
                    .SingleOrDefault();

                if (rjiTmp != null)
                {
                    rjiTmp.nivel = rji.nivel;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RelJugadorInvestigacion getRelJugadorInvestigacion(int id)
        {
            CostoHandlerEF costoH = new CostoHandlerEF(ctx);
            try
            {
                var invE = (from c in ctx.RelJugadorInvestigacion
                         where c.id == id
                         select c).SingleOrDefault();
                
                Jugador jug = new Jugador(invE.colonia.j.Id, invE.colonia.j.nombre, invE.colonia.j.apellido,
                                            invE.colonia.j.Email, invE.colonia.j.UserName, invE.colonia.j.PasswordHash,
                                            invE.colonia.j.foto, invE.colonia.j.nickname,
                                            invE.colonia.j.nivel, invE.colonia.j.experiencia);
                RelJugadorMapa col = new RelJugadorMapa(invE.colonia.id, invE.colonia.nivel1, invE.colonia.nivel2, invE.colonia.nivel3,
                                                        invE.colonia.nivel4, invE.colonia.nivel5, invE.colonia.coord, jug);
                var costos = new List<Costo>();
                foreach (var item in invE.investigacion.costos)
                {
                    var c = costoH.getCosto(item.Id);
                    costos.Add(c);
                }
                Investigacion inv = new Investigacion(invE.investigacion.id, invE.investigacion.nombre, invE.investigacion.descripcion,
                    invE.investigacion.foto,costos);

                RelJugadorInvestigacion investigacion = new RelJugadorInvestigacion(invE.id, col, inv, invE.nivel);
                return investigacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RelJugadorInvestigacion> getInvestigacionesByColonia(int id)
        {
            var investigaciones = new List<RelJugadorInvestigacion>();
            try
            {
                ctx.Database.Connection.Open();
                List<Entities.RelJugadorInvestigacion> invE = ctx.RelJugadorInvestigacion.Where(w => w.colonia.id == id).ToList();
                ctx.Database.Connection.Close();
                foreach (var item in invE)
                {
                    var rel = getRelJugadorInvestigacion(item.id);
                    investigaciones.Add(rel);
                }

                return investigaciones;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void subirNivelI(int id)
        {
            try
            {
                var r = ctx.RelJugadorInvestigacion
                    .Where(w => w.id == id)
                    .SingleOrDefault();

                if (r != null)
                {
                    r.nivel += 1;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void bajarNivelI(int id)
        {
            try
            {
                var r = ctx.RelJugadorInvestigacion
                   .Where(w => w.id == id)
                   .SingleOrDefault();

                if (r != null)
                {
                    r.nivel -= 1;
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
