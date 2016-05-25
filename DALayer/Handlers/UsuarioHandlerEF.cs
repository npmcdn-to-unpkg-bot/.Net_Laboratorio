using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Interfaces;
using SharedEntities.Entities;

namespace DALayer.Handlers
{
    class UsuarioHandlerEF : IUsuarioHandler
    {
        TenantContext ctx;

        public UsuarioHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createAdmin(Admin admin)
        {
            
        }

        public void createJugador(Jugador jugador)
        {
            Entities.Jugador jugE = new Entities.Jugador();
            jugE.nombre = jugador.name;
            jugE.apellido = jugador.apellidos;
            jugE.Email = jugador.email;
            jugE.UserName = jugador.UserName; 
            jugE.foto = jugador.foto;
            jugE.nickname = jugador.nickname;
            jugE.nivel = jugador.nivel;
            jugE.experiencia = jugador.experiencia;

            try
            {
                ctx.Jugador.Add(jugE);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void deleteAdmin(string id)
        {
            var admE = (from c in ctx.Admin
                        where c.Id.Equals(id)
                        select c).SingleOrDefault();
            try
            {
                ctx.Admin.Remove(admE);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteJugador(string id)
        {
            var jugE = (from c in ctx.Jugador
                        where c.Id.Equals(id)
                        select c).SingleOrDefault();
            try
            {
                ctx.Jugador.Remove(jugE);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Admin getAdmin(string id)
        {
            try
            {
                var admE = (from c in ctx.Admin
                             where c.Id.Equals(id)
                            select c).SingleOrDefault();

                Admin adm = new Admin(admE.Id, admE.nombre, admE.apellido, admE.Email, admE.UserName, 
                    admE.foto, admE.telefono);
                return adm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Admin> getAllAdmins()
        {
            List<Admin> admins = new List<Admin>();
            try
            {
                List<Entities.Admin> adE = ctx.Admin.ToList();
                foreach (Entities.Admin item in adE)
                {
                    Admin temp = new Admin(item.Id, item.nombre, item.apellido, item.Email, item.UserName,
                    item.foto, item.telefono);
                    admins.Add(temp);
                }

                return admins;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Jugador> getAllJugadores()
        {
            List<Jugador> jugadores = new List<Jugador>();
            try
            {
                List<Entities.Jugador> jugE = ctx.Jugador.ToList();
                foreach (Entities.Jugador item in jugE)
                {
                    Jugador temp = new Jugador(item.Id, item.nombre, item.apellido, item.Email, item.UserName,
                    item.foto, item.nickname, item.nivel, item.experiencia);
                    jugadores.Add(temp);
                }

                return jugadores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Jugador getJugador(string id)
        {
            try
            {
                var jugE = (from c in ctx.Jugador
                            where c.Id.Equals(id)
                            select c).SingleOrDefault();

                Jugador jug = new Jugador(jugE.Id, jugE.nombre, jugE.apellido, jugE.Email, jugE.UserName,
                    jugE.foto, jugE.nickname, jugE.nivel, jugE.experiencia);
                return jug;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateAdmin(Admin admin)
        {
            try
            {
                var adminE = ctx.Admin
                    .Where(w => w.Id.Equals(admin.id))
                    .SingleOrDefault();

                if (adminE != null)
                {
                    adminE.Id = admin.Id;
                    adminE.nombre = admin.name;
                    adminE.apellido = admin.apellidos;
                    adminE.Email = admin.email;
                    adminE.UserName = admin.usuario; 
                    adminE.foto = admin.foto;
                    adminE.telefono = admin.telefono;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateJugador(Jugador jugador)
        {
            try
            {
                var jugadorE = ctx.Jugador
                    .Where(w => w.Id.Equals(jugador.Id))
                    .SingleOrDefault();

                if (jugadorE != null)
                {
                    jugadorE.Id = jugador.Id;
                    jugadorE.nombre = jugador.name;
                    jugadorE.apellido = jugador.apellidos;
                    jugadorE.Email = jugador.email;
                    jugadorE.UserName = jugador.usuario; 
                    jugadorE.foto = jugador.foto;
                    jugadorE.nickname = jugador.nickname;
                    jugadorE.nivel = jugador.nivel;
                    jugadorE.experiencia = jugador.experiencia;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
}
    }
}
