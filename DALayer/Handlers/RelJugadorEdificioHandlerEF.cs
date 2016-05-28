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
        public void createRelJugadorEdificio(RelJugadorEdificio rjeTmp)
        {
            Entities.RelJugadorEdificio rje = new Entities.RelJugadorEdificio();
            
            //pasa edificio de SharedEntities a Entities
            pasarEdificioShaToEnt(rje.edificio, rjeTmp.edificio);
            //pasa colonia de SharedEntities a Entities
            pasarColoniaShaToEnt(rje.colonia, rjeTmp.colonia);
            rje.nivelE = rjeTmp.nivelE;

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

                Edificio edi = new Edificio(rje.edificio.id, rje.edificio.descripcion, rje.edificio.foto, rje.edificio.ataque,
                                            rje.edificio.escudo, rje.edificio.efectividadAtaque, rje.edificio.vida, rje.edificio.nombre);
                Jugador jug2 = new Jugador(rje.colonia.j.Id, rje.colonia.j.nombre, rje.colonia.j.apellido,
                                            rje.colonia.j.Email, rje.colonia.j.UserName, rje.colonia.j.PasswordHash,
                                            rje.colonia.j.foto, rje.colonia.j.nickname,
                                            rje.colonia.j.nivel, rje.colonia.j.experiencia);
                RelJugadorMapa col = new RelJugadorMapa(rje.colonia.id, rje.colonia.nivel1, rje.colonia.nivel2, rje.colonia.nivel3,
                                                        rje.colonia.nivel4, rje.colonia.nivel5, jug2);
                pasarColoniaEntToSha(col, rje.colonia);
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
                var rjeTmp = ctx.RelJugadorEdificio
                    .Where(w => w.id == rje.id)
                    .SingleOrDefault();

                if (rjeTmp != null)
                {
                    pasarEdificioShaToEnt(rjeTmp.edificio, rje.edificio);
                    pasarColoniaShaToEnt(rjeTmp.colonia, rje.colonia);
                    rjeTmp.nivelE = rje.nivelE;
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
            throw new NotImplementedException();
        }

        private void pasarJugadorShaToEnt(Entities.Jugador jugEnt, Jugador jugSha)
        {
            jugEnt.nombre = jugSha.nombre;
            jugEnt.apellido = jugSha.apellido;
            jugEnt.Email = jugSha.email;
            jugEnt.UserName = jugSha.usuario;
            jugEnt.foto = jugSha.foto;
            jugEnt.nickname = jugSha.nickname;
            jugEnt.nivel = jugSha.nivel;
            jugEnt.experiencia = jugSha.experiencia;
        }

        private void pasarJugadorEntToSha(Jugador jugEnt, Entities.Jugador jugSha)
        {
            jugSha.nombre = jugEnt.nombre;
            jugSha.apellido = jugEnt.apellido;
            jugSha.Email = jugEnt.email;
            jugSha.UserName = jugEnt.usuario;
            jugSha.foto = jugEnt.foto;
            jugSha.nickname = jugEnt.nickname;
            jugSha.nivel = jugEnt.nivel;
            jugSha.experiencia = jugEnt.experiencia;
        }

        private void pasarEdificioShaToEnt(Entities.Edificio ediEnt, Edificio ediSha)
        {
            ediEnt.id = ediSha.id;
            ediEnt.nombre = ediSha.nombre;
            ediEnt.descripcion = ediSha.descripcion;
            ediEnt.foto = ediSha.foto;
            ediEnt.ataque = ediSha.ataque;
            ediEnt.escudo = ediSha.escudo;
            ediEnt.efectividadAtaque = ediSha.efectividadAtaque;
            ediEnt.vida = ediSha.vida;
        }

        private void pasarEdificioEntToSha(Edificio ediSha, Entities.Edificio ediEnt)
        {
            ediSha.id = ediEnt.id;
            ediSha.nombre = ediEnt.nombre;
            ediSha.descripcion = ediEnt.descripcion;
            ediSha.foto = ediEnt.foto;
            ediSha.ataque = ediEnt.ataque;
            ediSha.escudo = ediEnt.escudo;
            ediSha.efectividadAtaque = ediEnt.efectividadAtaque;
            ediSha.vida = ediEnt.vida;
        }

        private void pasarColoniaShaToEnt(Entities.RelJugadorMapa relEnt, RelJugadorMapa relSha)
        {
            relEnt.id = relSha.id;
            pasarJugadorShaToEnt(relEnt.j, relSha.jugador);
            relEnt.nivel1 = relSha.nivel1;
            relEnt.nivel2 = relSha.nivel2;
            relEnt.nivel3 = relSha.nivel3;
            relEnt.nivel4 = relSha.nivel4;
            relEnt.nivel5 = relSha.nivel5;
        }

        private void pasarColoniaEntToSha(RelJugadorMapa relSha, Entities.RelJugadorMapa relEnt)
        {
            relSha.id = relEnt.id;
            pasarJugadorEntToSha(relSha.jugador, relEnt.j);
            relSha.nivel1 = relEnt.nivel1;
            relSha.nivel2 = relEnt.nivel2;
            relSha.nivel3 = relEnt.nivel3;
            relSha.nivel4 = relEnt.nivel4;
            relSha.nivel5 = relEnt.nivel5;
        }
    }
}
