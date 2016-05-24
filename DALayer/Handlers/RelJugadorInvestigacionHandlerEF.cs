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
            var j2 = new Entities.Jugador(r.colonia.jugador.nombre, r.colonia.jugador.apellido, r.colonia.jugador.foto,
                r.colonia.jugador.nickname, r.colonia.jugador.nivel, r.colonia.jugador.experiencia);
            j2.Id = r.colonia.jugador.id;
            var col = new Entities.RelJugadorMapa(r.colonia.nivel1, r.colonia.nivel2, r.colonia.nivel3, r.colonia.nivel4,
                r.colonia.nivel5, j2);
            col.id = r.colonia.id;

            List<Entities.Costo> cos = new List<Entities.Costo>();
            foreach (var item in r.investigacion.costos)
            {
                var c = new Entities.Costo(item.idRecurso, item.valor, item.incrementoNivel);
                cos.Add(c);
            }
            var inv = new Entities.Investigacion(r.investigacion.nombre, r.investigacion.descripcion, r.investigacion.foto,
                cos, r.investigacion.factorCostoNivel);
            inv.id = r.investigacion.id;

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
                                                        invE.colonia.nivel4, invE.colonia.nivel5, jug);
                var costos = new List<Costo>();
                foreach (var item in invE.investigacion.costos)
                {
                    var c = new Costo(item.idRecurso, item.valor, item.incrementoNivel);
                    costos.Add(c);
                }
                Investigacion inv = new Investigacion(invE.investigacion.id, invE.investigacion.nombre, invE.investigacion.descripcion,
                    invE.investigacion.foto, costos, invE.investigacion.factorCostoNivel);

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
    }
}
