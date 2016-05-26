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
    public class RelJugadorRecursoHandlerEF : IRelJugadorRecursoHandler
    {
        TenantContext ctx;
        public RelJugadorRecursoHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }
        public void createRelJugadorRecurso(RelJugadorRecurso rjrTmp)
        {
            Entities.RelJugadorRecurso rjr = new Entities.RelJugadorRecurso();
            
            //pasa jugador de SharedEntities a Entities 
            pasarJugadorShaToEnt(rjr.jugador, rjrTmp.jugador);
            //pasa recurso de SharedEntities a Entities
            pasarRecursoShaToEnt(rjr.recurso, rjrTmp.recurso);
            //pasa colonia de SharedEntities a Entities
            pasarColoniaShaToEnt(rjr.colonia, rjrTmp.colonia);
            rjr.capacidad = rjrTmp.capacidad;
            rjr.cantidadR = rjrTmp.cantidadR;
            rjr.factorIncremento = rjrTmp.factorIncremento;

            try
            {
                ctx.RelJugadorRecurso.Add(rjr);

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteRelJugadorRecurso(int id)
        {
            var rjr = (from c in ctx.RelJugadorRecurso
                       where c.id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.RelJugadorRecurso.Remove(rjr);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RelJugadorRecurso> getAllRelJugadorRecurso()
        {
            List<RelJugadorRecurso> listRel = new List<RelJugadorRecurso>();
            try
            {
                List<Entities.RelJugadorRecurso> rjrTmp = ctx.RelJugadorRecurso.ToList();
                foreach (Entities.RelJugadorRecurso item in rjrTmp)
                {
                    Jugador jug = new Jugador(item.jugador.Id, item.jugador.nombre, item.jugador.apellido,
                                              item.jugador.Email, item.jugador.UserName, item.jugador.foto,
                                              item.jugador.nickname, item.jugador.nivel, item.jugador.experiencia);
                    Recurso rec = new Recurso(item.recurso.id, item.recurso.nombre, item.recurso.descripcion, item.recurso.foto);
                    Jugador jug2 = new Jugador(item.colonia.jugador.Id, item.colonia.jugador.nombre, item.colonia.jugador.apellido,
                                                item.colonia.jugador.Email, item.colonia.jugador.UserName,
                                                item.colonia.jugador.foto, item.colonia.jugador.nickname,
                                                item.colonia.jugador.nivel, item.colonia.jugador.experiencia);
                    RelJugadorMapa col = new RelJugadorMapa(item.colonia.id, item.colonia.nivel1, item.colonia.nivel2, item.colonia.nivel3,
                                                            item.colonia.nivel4, item.colonia.nivel5, jug2);
                    pasarColoniaEntToSha(col, item.colonia);
                    RelJugadorRecurso rel = new RelJugadorRecurso(item.id, jug , rec, col, item.cantidadR, 
                                                                    item.capacidad, item.factorIncremento);
                    listRel.Add(rel);
                }
                return listRel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RelJugadorRecurso getRelJugadorRecurso(int id)
        {
            try
            {
                var rjr = (from c in ctx.RelJugadorRecurso
                           where c.id == id
                           select c).SingleOrDefault();
                Jugador jug = new Jugador(rjr.jugador.Id, rjr.jugador.nombre, rjr.jugador.apellido,
                                          rjr.jugador.Email, rjr.jugador.UserName, rjr.jugador.foto,
                                          rjr.jugador.nickname, rjr.jugador.nivel, rjr.jugador.experiencia);
                Recurso rec = new Recurso(rjr.recurso.id, rjr.recurso.nombre, rjr.recurso.descripcion, rjr.recurso.foto);
                Jugador jug2 = new Jugador(rjr.colonia.jugador.Id, rjr.colonia.jugador.nombre, rjr.colonia.jugador.apellido,
                                            rjr.colonia.jugador.Email, rjr.colonia.jugador.UserName,
                                            rjr.colonia.jugador.foto, rjr.colonia.jugador.nickname,
                                            rjr.colonia.jugador.nivel, rjr.colonia.jugador.experiencia);
                RelJugadorMapa col = new RelJugadorMapa(rjr.colonia.id, rjr.colonia.nivel1, rjr.colonia.nivel2, rjr.colonia.nivel3,
                                                        rjr.colonia.nivel4, rjr.colonia.nivel5, jug2);
                pasarColoniaEntToSha(col, rjr.colonia);
                RelJugadorRecurso relacion = new RelJugadorRecurso(rjr.id, jug, rec, col, rjr.capacidad, rjr.cantidadR, rjr.factorIncremento);
                return relacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateRelJugadorRecurso(RelJugadorRecurso rjr)
        {
            try
            {
                var rjrTmp = ctx.RelJugadorRecurso
                    .Where(w => w.id == rjr.id)
                    .SingleOrDefault();

                if (rjrTmp != null)
                {
                    pasarJugadorShaToEnt(rjrTmp.jugador, rjr.jugador);
                    pasarRecursoShaToEnt(rjrTmp.recurso, rjr.recurso);
                    pasarColoniaShaToEnt(rjrTmp.colonia, rjr.colonia);
                    rjrTmp.capacidad = rjr.capacidad;
                    rjrTmp.cantidadR = rjr.cantidadR;
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

        private void pasarRecursoShaToEnt(Entities.Recurso recEnt, Recurso recSha)
        {
            recEnt.id = recSha.id;
            recEnt.nombre = recSha.nombre;
            recEnt.descripcion = recSha.descripcion;
            recEnt.foto = recSha.foto;
        }

        private void pasarRecursoEntToSha(Recurso recSha, Entities.Recurso recEnt)
        {
            recSha.id = recEnt.id;
            recSha.nombre = recEnt.nombre;
            recSha.descripcion = recEnt.descripcion;
            recSha.foto = recEnt.foto;
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
