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
        public void createRelJugadorInvestigacion(RelJugadorInvestigacion rjiTmp)
        {
            Entities.RelJugadorInvestigacion rji = new Entities.RelJugadorInvestigacion();

            //pasa jugador de SharedEntities a Entities 
            pasarJugadorShaToEnt(rji.jugador, rjiTmp.jugador);
            //pasa investigacion de SharedEntities a Entities
            pasarInvestigacionShaToEnt(rji.investigacion, rjiTmp.investigacion);
            //pasa colonia de SharedEntities a Entities
            pasarColoniaShaToEnt(rji.colonia, rjiTmp.colonia);
            rji.nivel = rjiTmp.nivel;

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

        public List<RelJugadorInvestigacion> getAllRelJugadorInvestigacion()
        {
            List<RelJugadorInvestigacion> listRel = new List<RelJugadorInvestigacion>();
            try
            {
                List<Entities.RelJugadorInvestigacion> rjiTmp = ctx.RelJugadorInvestigacion.ToList();
                foreach (Entities.RelJugadorInvestigacion item in rjiTmp)
                {
                    Jugador jug = new Jugador(item.jugador.Id, item.jugador.nombre, item.jugador.apellido,
                                              item.jugador.Email, item.jugador.UserName, item.jugador.foto,
                                              item.jugador.nickname, item.jugador.nivel, item.jugador.experiencia);
                    Investigacion inv = new Investigacion(item.investigacion.id, item.investigacion.nombre, item.investigacion.descripcion, 
                                                          item.investigacion.foto, item.investigacion.costo, item.investigacion.factorCostoNivel,
                                                          item.nivel);
                    Jugador jug2 = new Jugador(item.colonia.jugador.Id, item.colonia.jugador.nombre, item.colonia.jugador.apellido,
                                                item.colonia.jugador.Email, item.colonia.jugador.UserName,
                                                item.colonia.jugador.foto, item.colonia.jugador.nickname,
                                                item.colonia.jugador.nivel, item.colonia.jugador.experiencia);
                    RelJugadorMapa col = new RelJugadorMapa(item.colonia.id, item.colonia.nivel1, item.colonia.nivel2, item.colonia.nivel3,
                                                            item.colonia.nivel4, item.colonia.nivel5, jug2);
                    pasarColoniaEntToSha(col, item.colonia);
                    RelJugadorInvestigacion rel = new RelJugadorInvestigacion(item.id, jug, col, inv, item.nivel);
                                                                    
                    listRel.Add(rel);
                }
                return listRel;
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
                var rji = (from c in ctx.RelJugadorInvestigacion
                           where c.id == id
                           select c).SingleOrDefault();
                Jugador jug = new Jugador(rji.jugador.Id, rji.jugador.nombre, rji.jugador.apellido,
                                          rji.jugador.Email, rji.jugador.UserName, rji.jugador.foto,
                                          rji.jugador.nickname, rji.jugador.nivel, rji.jugador.experiencia);
                Investigacion inv = new Investigacion(rji.investigacion.id, rji.investigacion.nombre, rji.investigacion.descripcion, 
                                                        rji.investigacion.foto, rji.investigacion.costo, 
                                                        rji.investigacion.factorCostoNivel, rji.investigacion.nivel);
                Jugador jug2 = new Jugador(rji.colonia.jugador.Id, rji.colonia.jugador.nombre, rji.colonia.jugador.apellido,
                                            rji.colonia.jugador.Email, rji.colonia.jugador.UserName,
                                            rji.colonia.jugador.foto, rji.colonia.jugador.nickname,
                                            rji.colonia.jugador.nivel, rji.colonia.jugador.experiencia);
                RelJugadorMapa col = new RelJugadorMapa(rji.colonia.id, rji.colonia.nivel1, rji.colonia.nivel2, rji.colonia.nivel3,
                                                        rji.colonia.nivel4, rji.colonia.nivel5, jug2);
                pasarColoniaEntToSha(col, rji.colonia);
                RelJugadorInvestigacion investigacion = new RelJugadorInvestigacion(rji.id, jug, col, inv, rji.nivel);
                return investigacion;
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
                    pasarJugadorShaToEnt(rjiTmp.jugador, rji.jugador);
                    pasarInvestigacionShaToEnt(rjiTmp.investigacion, rji.investigacion);
                    pasarColoniaShaToEnt(rjiTmp.colonia, rji.colonia);
                    rjiTmp.nivel = rji.nivel;
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

        private void pasarInvestigacionShaToEnt(Entities.Investigacion invEnt, Investigacion invSha)
        {
            invEnt.id = invSha.id;
            invEnt.nombre = invSha.nombre;
            invEnt.descripcion = invSha.descripcion;
            invEnt.foto = invSha.foto;
            invEnt.nivel = invSha.nivel;
            invEnt.factorCostoNivel = invSha.factorCostoNivel;
        }

        private void pasarInvestigacionEntToSha(Investigacion invSha, Entities.Investigacion invEnt)
        {
            invSha.id = invEnt.id;
            invSha.nombre = invEnt.nombre;
            invSha.descripcion = invEnt.descripcion;
            invSha.foto = invEnt.foto;
            invSha.nivel = invEnt.nivel;
            invSha.factorCostoNivel = invEnt.factorCostoNivel;
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
