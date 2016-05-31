using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Interfaces;
using SharedEntities.Entities;

namespace DALayer.Handlers
{
    public class RelJugadorMapaHandlerEF : IRelJugadorMapaHandler
    {
        TenantContext ctx;
        public RelJugadorMapaHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createRelJugadorMapa(RelJugadorMapa r)
        {
            var j = ctx.Jugador.Where(w => w.Id == r.jugador.id).SingleOrDefault();
            var rel = new Entities.RelJugadorMapa(r.nivel1, r.nivel2, r.nivel3, r.nivel4, r.nivel5, j);
            try
            {
                ctx.RelJugadorMapa.Add(rel);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteRelJugadorMapa(int id)
        {
            var rel = (from c in ctx.RelJugadorMapa
                       where c.id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.RelJugadorMapa.Remove(rel);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RelJugadorMapa getRelJugadorMapa(int id)
        {
            try
            {
                var rel = (from c in ctx.RelJugadorMapa
                           where c.id == id
                           select c).SingleOrDefault();

                var j = new Jugador(rel.j.Id, rel.j.nombre, rel.j.apellido, rel.j.Email, rel.j.UserName, rel.j.PasswordHash, rel.j.foto,
                    rel.j.nickname, rel.j.nivel, rel.j.experiencia);
                var rjm = new RelJugadorMapa(rel.id, rel.nivel1, rel.nivel2, rel.nivel3, rel.nivel4, rel.nivel5, j);
                return rjm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateRelJugadorMapa(RelJugadorMapa r)
        {
            try
            {
                var rel = ctx.RelJugadorMapa
                    .Where(w => w.id == r.id)
                    .SingleOrDefault();

                if (rel != null)
                {
                    rel.nivel1 = r.nivel1;
                    rel.nivel2 = r.nivel2;
                    rel.nivel3 = r.nivel3;
                    rel.nivel4 = r.nivel4;
                    rel.nivel5 = r.nivel5;
                    rel.j = new Entities.Jugador(r.jugador.nombre, r.jugador.apellido, r.jugador.foto, r.jugador.nickname,
                        r.jugador.nivel, r.jugador.experiencia);

                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RelJugadorMapa> getMapasByJugador(Jugador j)
        {
            var mapas = new List<RelJugadorMapa>();
            try
            {
                ctx.Database.Connection.Open();
                List<Entities.RelJugadorMapa> mapasE = ctx.RelJugadorMapa.Where(w => w.j.Id == j.id).ToList();
                ctx.Database.Connection.Close();
                foreach (var item in mapasE)
                {
                    var rel = getRelJugadorMapa(item.id);
                    mapas.Add(rel);
                }

                return mapas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RelJugadorMapa> getColoniasByCoord(int n1, int n2, int n3, int n4)
        {
            throw new NotImplementedException();
        }
    }
}
