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
    public class RelJugadorEdificioHandlerEF : IRelJugadorEdificioHandler
    {
        TenantContext ctx;
        public RelJugadorEdificioHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createRelJugadorEdificio(RelJugadorEdificio r)
        {
            var j2 = new Entities.Jugador(r.colonia.jugador.nombre, r.colonia.jugador.apellido, r.colonia.jugador.foto,
                r.colonia.jugador.nickname, r.colonia.jugador.nivel, r.colonia.jugador.experiencia);
            j2.Id = r.colonia.jugador.id;
            var col = new Entities.RelJugadorMapa(r.colonia.nivel1, r.colonia.nivel2, r.colonia.nivel3, r.colonia.nivel4,
                r.colonia.nivel5, j2);
            col.id = r.colonia.id;

            List<Entities.Costo> cos = new List<Entities.Costo>();
            foreach (var item in r.edificio.costos)
            {
                var c = new Entities.Costo(item.idRecurso, item.valor, item.incrementoNivel);
                cos.Add(c);
            }
            List<Entities.Capacidad> cap = new List<Entities.Capacidad>();
            foreach (var item in r.edificio.capacidad)
            {
                var c = new Entities.Capacidad(item.idRecurso, item.valor, item.incrementoNivel);
                cap.Add(c);
            }
            var ed = new Entities.Edificio(r.edificio.nombre, r.edificio.descripcion, r.edificio.foto, cos,
                cap, r.edificio.ataque, r.edificio.escudo, r.edificio.efectividadAtaque, r.edificio.vida);
            ed.id = r.edificio.id;

            var rje = new Entities.RelJugadorEdificio(col, ed, r.nivelE);

            try
            {
                ctx.RelJugadorEdificio.Add(rje);

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteRelJugadorEdificio(int id)
        {
            var rje = (from c in ctx.RelJugadorEdificio
                       where c.id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.RelJugadorEdificio.Remove(rje);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RelJugadorEdificio getRelJugadorEdificio(int id)
        {
            try
            {
                var rje = (from c in ctx.RelJugadorEdificio
                           where c.id == id
                           select c).SingleOrDefault();

                List<Costo> cos = new List<Costo>();
                foreach (var item2 in rje.edificio.costos)
                {
                    var c = new Costo(item2.idRecurso, item2.valor, item2.incrementoNivel);
                    cos.Add(c);
                }
                Edificio edi = new Edificio(rje.edificio.id, rje.edificio.descripcion, rje.edificio.foto, rje.edificio.ataque,
                                            rje.edificio.escudo, rje.edificio.efectividadAtaque, rje.edificio.vida,
                                            rje.edificio.nombre, cos);
                Jugador jug = new Jugador(rje.colonia.j.Id, rje.colonia.j.nombre, rje.colonia.j.apellido,
                                            rje.colonia.j.Email, rje.colonia.j.UserName, rje.colonia.j.PasswordHash,
                                            rje.colonia.j.foto, rje.colonia.j.nickname,
                                            rje.colonia.j.nivel, rje.colonia.j.experiencia);
                RelJugadorMapa col = new RelJugadorMapa(rje.colonia.id, rje.colonia.nivel1, rje.colonia.nivel2, rje.colonia.nivel3,
                                                        rje.colonia.nivel4, rje.colonia.nivel5, jug);
                RelJugadorEdificio edificio = new RelJugadorEdificio(rje.id, col, edi, rje.nivelE);
                return edificio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateRelJugadorEdificio(RelJugadorEdificio rje)
        {
            try
            {
                var r = ctx.RelJugadorEdificio
                    .Where(w => w.id == rje.id)
                    .SingleOrDefault();

                if (r != null)
                {
                    r.nivelE = rje.nivelE;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RelJugadorEdificio> getEdificiosByColonia(int id)
        {
            var edificios = new List<RelJugadorEdificio>();
            try
            {
                ctx.Database.Connection.Open();
                List<Entities.RelJugadorEdificio> edificiosE = ctx.RelJugadorEdificio.Where(w => w.colonia.id == id).ToList();
                ctx.Database.Connection.Close();
                foreach (var item in edificiosE)
                {
                    var ed = getRelJugadorEdificio(item.id);
                    edificios.Add(ed);
                }

                return edificios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
