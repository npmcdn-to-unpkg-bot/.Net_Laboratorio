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
            var rel = new Entities.RelJugadorMapa(r.nivel1, r.nivel2, r.nivel3, r.nivel4, r.nivel5, r.coord, j);
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
                var rjm = new RelJugadorMapa(rel.id, rel.nivel1, rel.nivel2, rel.nivel3, rel.nivel4, rel.nivel5, rel.coord, j);
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

        public List<RelJugadorMapa> getMapasByJugador(string id)
        {
            var mapas = new List<RelJugadorMapa>();
            try
            {
                ctx.Database.Connection.Open();
                List<Entities.RelJugadorMapa> mapasE = ctx.RelJugadorMapa.Where(w => w.j.Id == id).ToList();
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
        
        public Boolean existeColonia(int n1, int n2, int n3, int n4, int n5)
        {
            var hayMapa = ctx.RelJugadorMapa.Where(w => w.nivel1 == n1 && w.nivel2 == n2 && w.nivel3 == n3 && w.nivel4 == n4 && w.nivel5 == n5).FirstOrDefault();
            if (hayMapa == null)
            {
                return false;
            }
            return true;
        }

        public List<RelJugadorMapa> getColoniasPorVista(int[] coordenadas)
        {
            string coord = "/";
            foreach (var num in coordenadas)
            {
                coord += num.ToString() + "/";
            }

            List<Entities.RelJugadorMapa> colE = ctx.RelJugadorMapa.Where(w => w.coord == coord).ToList();
            List<RelJugadorMapa> colonias = new List<RelJugadorMapa>();
            foreach (var item in colE)
            {
                var colS = getRelJugadorMapa(item.id);
                colonias.Add(colS);
            }

            return colonias;
        }

        public void actualizarProduccionCapacidad(int idColonia)
        {
            var recHandler = new RecursosHandlerEF(ctx);
            var relJRHandler = new RelJugadorRecursoHandlerEF(ctx);
            var relJEHandler = new RelJugadorEdificioHandlerEF(ctx);
            var relJDHandler = new RelJugadorDestacamentoHandlerEF(ctx);
            var relJIHandler = new RelJugadorInvestigacionHandlerEF(ctx);

            var recursosColonia = relJRHandler.getRecursosByColonia(idColonia);
            var recursos = recHandler.getAllRecursos();
            var edificios = relJEHandler.getEdificiosByColonia(idColonia);
            var destacamentos = relJDHandler.getDestacamentosByColonia(idColonia);
            var investigaciones = relJIHandler.getInvestigacionesByColonia(idColonia);

            foreach (var rc in recursosColonia)
            {
                var r = recursos.First(w => w.id == rc.recurso.id);
                rc.produccionXTiempo = r.produccionXTiempo;
                rc.capacidad = r.capacidadInicial;

                foreach (var ed in edificios)
                {
                    if (ed.nivelE > 0)
                    {
                        var produce = ed.edificio.produce.FirstOrDefault(w => w.recurso.id == rc.recurso.id);
                        if (produce != null)
                        {
                            rc.produccionXTiempo += produce.valor;
                        }

                        var capacidad = ed.edificio.capacidad.FirstOrDefault(w => w.recurso.id == rc.recurso.id);
                        if (capacidad != null)
                        {
                            rc.capacidad += capacidad.valor;
                        }
                    }
                }

                foreach (var relJD in destacamentos)
                {
                    if (relJD.cantidad > 0)
                    {
                        var produce = relJD.destacamento.produce.FirstOrDefault(w => w.recurso.id == rc.recurso.id);
                        if (produce != null)
                        {
                            rc.produccionXTiempo += (produce.valor * relJD.cantidad);
                        }
                        var almacena = relJD.destacamento.capacidad.FirstOrDefault(w => w.recurso.id == rc.recurso.id);
                        if (almacena != null)
                        {
                            rc.capacidad += (almacena.valor * relJD.cantidad);
                        }
                    }
                }

                foreach (var relJI in investigaciones)
                {
                    if (relJI.nivel > 0)
                    {
                        var produce = relJI.investigacion.produce.FirstOrDefault(w => w.recurso.id == rc.recurso.id);
                        if (produce != null)
                        {
                            rc.produccionXTiempo *= produce.incrementoNivel;
                        }
                        var capacidad = relJI.investigacion.capacidad.FirstOrDefault(w => w.recurso.id == rc.recurso.id);
                        if (capacidad != null)
                        {
                            rc.capacidad = Convert.ToInt32(rc.capacidad * capacidad.incrementoNivel);
                        }
                    }
                }

                relJRHandler.updateRelJugadorRecurso(rc);
            }
        }
    }
}
