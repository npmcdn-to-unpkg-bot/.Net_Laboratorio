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

        public void updateRelJugadorInvestigacion(RelJugadorInvestigacion rji)
        {
            try
            {
                var rjiTmp = ctx.RelJugadorInvestigacion
                    .Where(w => w.id == rji.id)
                    .SingleOrDefault();

                if (rjiTmp != null)
                {
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

        public RelJugadorInvestigacion getRelJugadorInvestigacion(int id)
        {
            throw new NotImplementedException();
        }

        public List<RelJugadorInvestigacion> getInvestigacionesByColonia(int id)
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

        private void pasarInvestigacionShaToEnt(Entities.Investigacion invEnt, Investigacion invSha)
        {
            invEnt.id = invSha.id;
            invEnt.nombre = invSha.nombre;
            invEnt.descripcion = invSha.descripcion;
            invEnt.foto = invSha.foto;
            invEnt.factorCostoNivel = invSha.factorCostoNivel;
        }

        private void pasarInvestigacionEntToSha(Investigacion invSha, Entities.Investigacion invEnt)
        {
            invSha.id = invEnt.id;
            invSha.nombre = invEnt.nombre;
            invSha.descripcion = invEnt.descripcion;
            invSha.foto = invEnt.foto;
            invSha.factorCostoNivel = invEnt.factorCostoNivel;
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
