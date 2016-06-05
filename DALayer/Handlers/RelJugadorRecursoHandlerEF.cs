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

            var rjr = new Entities.RelJugadorRecurso(rec, col, r.capacidad, r.cantidadR, r.produccionXTiempo, r.ultimaConsulta);

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

                Recurso rec = new Recurso(r.recurso.id, r.recurso.nombre, r.recurso.descripcion, r.recurso.cantInicial,
                    r.recurso.capacidadInicial, r.recurso.produccionXTiempo, r.recurso.foto);
                Jugador jug = new Jugador(r.colonia.j.Id, r.colonia.j.nombre, r.colonia.j.apellido,
                                            r.colonia.j.Email, r.colonia.j.UserName, r.colonia.j.PasswordHash,
                                            r.colonia.j.foto, r.colonia.j.nickname,
                                            r.colonia.j.nivel, r.colonia.j.experiencia);
                RelJugadorMapa col = new RelJugadorMapa(r.colonia.id, r.colonia.nivel1, r.colonia.nivel2, r.colonia.nivel3,
                                                        r.colonia.nivel4, r.colonia.nivel5, r.colonia.coord, jug);
                RelJugadorRecurso relacion = new RelJugadorRecurso(r.id, rec, col, r.capacidad, r.cantidadR, r.produccionXTiempo, r.ultimaConsulta);
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
                    r.produccionXTiempo = rS.produccionXTiempo;
                    r.ultimaConsulta = rS.ultimaConsulta;
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
            calcularRecursosByIdCol(id);
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

        public void calcularRecursosByIdCol(int id)
        {
            var recursos = new List<RelJugadorRecurso>();
            ctx.Database.Connection.Open();
            List<Entities.RelJugadorRecurso> recursosE = ctx.RelJugadorRecurso.Where(w => w.colonia.id == id).ToList();
            ctx.Database.Connection.Close();
            foreach (var item in recursosE)
            {
                var rel = getRelJugadorRecurso(item.id);
                recursos.Add(rel);
            }
            
            DateTime ahora = DateTime.Now;
            TimeSpan dif = new TimeSpan();
            int segundos;
            foreach (var rec in recursos)
            {
                dif = ahora.Subtract(rec.ultimaConsulta);
                segundos = dif.Seconds;
                int prod = Convert.ToInt32((rec.produccionXTiempo * segundos) / 3600);
                if ((prod + rec.cantidadR) >= rec.capacidad)
                {
                    rec.cantidadR = rec.capacidad;
                }
                else
                {
                    rec.cantidadR += prod;
                }
                rec.ultimaConsulta = ahora;
                updateRelJugadorRecurso(rec);
            }
        }
    }
}
