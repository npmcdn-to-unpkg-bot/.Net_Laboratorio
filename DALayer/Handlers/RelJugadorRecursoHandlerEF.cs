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

        public void createRelJugadorRecurso(RelJugadorRecurso r)
        {
            var rec = ctx.Recurso.Where(w => w.id == r.recurso.id).SingleOrDefault();
            var col = ctx.RelJugadorMapa.Where(w => w.id == r.colonia.id).SingleOrDefault();

            var rjr = new Entities.RelJugadorRecurso(rec, col, r.capacidad, r.cantidadR, r.factorIncremento);

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

        public RelJugadorRecurso getRelJugadorRecurso(int id)
        {
            try
            {
                var r = (from c in ctx.RelJugadorRecurso
                           where c.id == id
                           select c).SingleOrDefault();

                Recurso rec = new Recurso(r.recurso.id, r.recurso.nombre, r.recurso.descripcion, r.recurso.cantInicial, r.recurso.foto);
                Jugador jug = new Jugador(r.colonia.j.Id, r.colonia.j.nombre, r.colonia.j.apellido,
                                            r.colonia.j.Email, r.colonia.j.UserName, r.colonia.j.PasswordHash,
                                            r.colonia.j.foto, r.colonia.j.nickname,
                                            r.colonia.j.nivel, r.colonia.j.experiencia);
                RelJugadorMapa col = new RelJugadorMapa(r.colonia.id, r.colonia.nivel1, r.colonia.nivel2, r.colonia.nivel3,
                                                        r.colonia.nivel4, r.colonia.nivel5, jug);
                RelJugadorRecurso relacion = new RelJugadorRecurso(r.id, rec, col, r.capacidad, r.cantidadR, r.factorIncremento);
                return relacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateRelJugadorRecurso(RelJugadorRecurso rS)
        {
            try
            {
                var r = ctx.RelJugadorRecurso
                    .Where(w => w.id == rS.id)
                    .SingleOrDefault();

                if (r != null)
                {
                    r.capacidad = rS.capacidad;
                    r.cantidadR = rS.cantidadR;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RelJugadorRecurso> getRecursosByColonia(int id)
        {
            var recursos = new List<RelJugadorRecurso>();
            try
            {
                ctx.Database.Connection.Open();
                List<Entities.RelJugadorRecurso> recursosE = ctx.RelJugadorRecurso.Where(w => w.colonia.id == id).ToList();
                ctx.Database.Connection.Close();
                foreach (var item in recursosE)
                {
                    var rel = getRelJugadorRecurso(item.id);
                    recursos.Add(rel);
                }

                return recursos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
