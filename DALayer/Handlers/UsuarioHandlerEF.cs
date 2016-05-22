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
            Entities.Admin admE = new Entities.Admin();
            admE.nombre = admin.name;
            admE.apellido = admin.apellidos;
            admE.email = admin.email;
            admE.usuario = admin.usuario;
            admE.password = admin.password;
            admE.foto = admin.foto;
            admE.telefono = admin.telefono;

            try
            {
                ctx.Admin.Add(admE);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void createJugador(Jugador jugador)
        {
            Entities.Jugador jugE = new Entities.Jugador();
            jugE.nombre = jugador.name;
            jugE.apellido = jugador.apellidos;
            jugE.email = jugador.email;
            jugE.usuario = jugador.usuario;
            jugE.password = jugador.password;
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

        public void deleteAdmin(int id)
        {
            var admE = (from c in ctx.Admin
                        where c.id == id
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

        public void deleteJugador(int id)
        {
            var jugE = (from c in ctx.Jugador
                        where c.id == id
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

        public Admin getAdmin(int id)
        {
            try
            {
                var admE = (from c in ctx.Admin
                             where c.id == id
                             select c).SingleOrDefault();

                Admin adm = new Admin(admE.id, admE.nombre, admE.apellido, admE.email, admE.usuario, admE.password,
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
                    Admin temp = new Admin(item.id, item.nombre, item.apellido, item.email, item.usuario, item.password,
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
                    Jugador temp = new Jugador(item.id, item.nombre, item.apellido, item.email, item.usuario, item.password,
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

        public Jugador getJugador(int id)
        {
            try
            {
                var jugE = (from c in ctx.Jugador
                            where c.id == id
                            select c).SingleOrDefault();

                Jugador jug = new Jugador(jugE.id, jugE.nombre, jugE.apellido, jugE.email, jugE.usuario, jugE.password,
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
                    .Where(w => w.id == admin.id)
                    .SingleOrDefault();

                if (adminE != null)
                {
                    adminE.id = admin.id;
                    adminE.nombre = admin.name;
                    adminE.apellido = admin.apellidos;
                    adminE.email = admin.email;
                    adminE.usuario = admin.usuario;
                    adminE.password = admin.password;
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
                    .Where(w => w.id == jugador.id)
                    .SingleOrDefault();

                if (jugadorE != null)
                {
                    jugadorE.id = jugador.id;
                    jugadorE.nombre = jugador.name;
                    jugadorE.apellido = jugador.apellidos;
                    jugadorE.email = jugador.email;
                    jugadorE.usuario = jugador.usuario;
                    jugadorE.password = jugador.password;
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
