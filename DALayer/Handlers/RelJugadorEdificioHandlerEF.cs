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

            //pasa jugador de SharedEntities a Entities 
            pasarJugadorShaToEnt(rje.jugador, rjeTmp.jugador);
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

        public List<RelJugadorEdificio> getAllRelJugadorEdificio()
        {
            List<RelJugadorEdificio> listRel = new List<RelJugadorEdificio>();
            try
            {
                List<Entities.RelJugadorEdificio> rjeTmp = ctx.RelJugadorEdificio.ToList();
                foreach (Entities.RelJugadorEdificio item in rjeTmp)
                {
                    Jugador jug = new Jugador(item.jugador.Id, item.jugador.nombre, item.jugador.apellido,
                                              item.jugador.Email, item.jugador.UserName, item.jugador.foto,
                                              item.jugador.nickname, item.jugador.nivel, item.jugador.experiencia);
                    Edificio edi = new Edificio(item.edificio.id, item.edificio.descripcion, item.edificio.foto, item.edificio.ataque,
                                                item.edificio.escudo, item.edificio.efectividadAtaque, item.edificio.vida,item.edificio.nombre);
                    Jugador jug2 = new Jugador(item.colonia.jugador.Id, item.colonia.jugador.nombre, item.colonia.jugador.apellido,
                                                item.colonia.jugador.Email, item.colonia.jugador.UserName,
                                                item.colonia.jugador.foto, item.colonia.jugador.nickname,
                                                item.colonia.jugador.nivel, item.colonia.jugador.experiencia);
                    RelJugadorMapa col = new RelJugadorMapa(item.colonia.id, item.colonia.nivel1, item.colonia.nivel2, item.colonia.nivel3,
                                                            item.colonia.nivel4, item.colonia.nivel5, jug2);
                    pasarColoniaEntToSha(col, item.colonia);
                    RelJugadorEdificio rel = new RelJugadorEdificio(item.id, jug, col, edi, item.nivelE);

                    listRel.Add(rel);
                }
                return listRel;
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
                Jugador jug = new Jugador(rje.jugador.Id, rje.jugador.nombre, rje.jugador.apellido,
                                          rje.jugador.Email, rje.jugador.UserName, rje.jugador.foto,
                                          rje.jugador.nickname, rje.jugador.nivel, rje.jugador.experiencia);
                Edificio edi = new Edificio(rje.edificio.id, rje.edificio.descripcion, rje.edificio.foto, rje.edificio.ataque,
                                            rje.edificio.escudo, rje.edificio.efectividadAtaque, rje.edificio.vida, rje.edificio.nombre); 
                Jugador jug2 = new Jugador(rje.colonia.jugador.Id, rje.colonia.jugador.nombre, rje.colonia.jugador.apellido,
                                            rje.colonia.jugador.Email, rje.colonia.jugador.UserName,
                                            rje.colonia.jugador.foto, rje.colonia.jugador.nickname,
                                            rje.colonia.jugador.nivel, rje.colonia.jugador.experiencia);
                RelJugadorMapa col = new RelJugadorMapa(rje.colonia.id, rje.colonia.nivel1, rje.colonia.nivel2, rje.colonia.nivel3,
                                                        rje.colonia.nivel4, rje.colonia.nivel5, jug2);
                pasarColoniaEntToSha(col, rje.colonia);
                RelJugadorEdificio edificio = new RelJugadorEdificio(rje.id, jug, col, edi, rje.nivelE);
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
                    pasarJugadorShaToEnt(rjeTmp.jugador, rje.jugador);
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

        private void pasarJugadorShaToEnt(Entities.Jugador jugEnt, Jugador jugSha)
        {
            jugEnt.Id = jugSha.Id;
            jugEnt.nombre = jugSha.name;
            jugEnt.apellido = jugSha.apellidos;
            jugEnt.Email = jugSha.email;
            jugEnt.UserName = jugSha.usuario;
            jugEnt.foto = jugSha.foto;
            jugEnt.nickname = jugSha.nickname;
            jugEnt.nivel = jugSha.nivel;
            jugEnt.experiencia = jugSha.experiencia;
        }

        private void pasarJugadorEntToSha(Jugador jugEnt, Entities.Jugador jugSha)
        {
            jugSha.Id = jugEnt.Id;
            jugSha.nombre = jugEnt.name;
            jugSha.apellido = jugEnt.apellidos;
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
            pasarJugadorShaToEnt(relEnt.jugador, relSha.jugador);
            relEnt.nivel1 = relSha.nivel1;
            relEnt.nivel2 = relSha.nivel2;
            relEnt.nivel3 = relSha.nivel3;
            relEnt.nivel4 = relSha.nivel4;
            relEnt.nivel5 = relSha.nivel5;
        }

        private void pasarColoniaEntToSha(RelJugadorMapa relSha, Entities.RelJugadorMapa relEnt)
        {
            relSha.id = relEnt.id;
            pasarJugadorEntToSha(relSha.jugador, relEnt.jugador);
            relSha.nivel1 = relEnt.nivel1;
            relSha.nivel2 = relEnt.nivel2;
            relSha.nivel3 = relEnt.nivel3;
            relSha.nivel4 = relEnt.nivel4;
            relSha.nivel5 = relEnt.nivel5;
        }
    }
}
