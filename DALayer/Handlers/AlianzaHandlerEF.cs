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
    public class AlianzaHandlerEF : IAlianzaHandler 
    {
        TenantContext ctx;
        public AlianzaHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createAlianza(Alianza alliTmp)
        {
            Entities.Alianza alli = new Entities.Alianza();

            alli.nombre = alliTmp.nombre;

            alli.miembros = new List<Entities.Jugador>();
            foreach (Jugador item in alliTmp.miembros)
            {
                Entities.Jugador jug = new Entities.Jugador();
                jug.apellido = item.apellidos;
                jug.email = item.email;
                jug.experiencia = item.experiencia;
                jug.foto = item.foto;
                jug.id = item.id;
                jug.nickname = item.nickname;
                jug.nivel = item.nivel;
                jug.password =item.password;
                jug.usuario = item.usuario;
                alli.miembros.Add(jug);
            }

            alli.admins = new List<Entities.Jugador>();
            foreach (Jugador item2 in alliTmp.admins)
            {
                Entities.Jugador jug2 = new Entities.Jugador();
                jug2.apellido = item2.apellidos;
                jug2.email = item2.email;
                jug2.experiencia = item2.experiencia;
                jug2.foto = item2.foto;
                jug2.id = item2.id;
                jug2.nickname = item2.nickname;
                jug2.nivel = item2.nivel;
                jug2.password = item2.password;
                jug2.usuario = item2.usuario;
                alli.admins.Add(jug2);
            }

            alli.descripcion = alliTmp.descripcion;
            alli.foto = alliTmp.foto;

            ctx.Alianza.Add(alli);

            try
            {

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void deleteAlianza(int id)
        {
            var alli = (from c in ctx.Alianza
                       where c.id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.Alianza.Remove(alli);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void updateAlianza(Alianza alli)
        {
            try
            {
                var alliTmp = ctx.Alianza
                    .Where(w => w.nombre == alli.nombre)
                    .SingleOrDefault();

                if (alliTmp != null)
                {
                    alliTmp.descripcion = alli.descripcion;
                    alliTmp.foto = alli.foto;

                    alliTmp.miembros = new List<Entities.Jugador>();
                    foreach (Jugador item in alli.miembros)
                    {
                        Entities.Jugador jug = new Entities.Jugador();
                        jug.apellido = item.apellidos;
                        jug.email = item.email;
                        jug.experiencia = item.experiencia;
                        jug.foto = item.foto;
                        jug.id = item.id;
                        jug.nickname = item.nickname;
                        jug.nivel = item.nivel;
                        jug.password = item.password;
                        jug.usuario = item.usuario;
                        alliTmp.miembros.Add(jug);
                    }

                    alliTmp.admins = new List<Entities.Jugador>();
                    foreach (Jugador item2 in alli.admins)
                    {
                        Entities.Jugador jug2 = new Entities.Jugador();
                        jug2.apellido = item2.apellidos;
                        jug2.email = item2.email;
                        jug2.experiencia = item2.experiencia;
                        jug2.foto = item2.foto;
                        jug2.id = item2.id;
                        jug2.nickname = item2.nickname;
                        jug2.nivel = item2.nivel;
                        jug2.password = item2.password;
                        jug2.usuario = item2.usuario;
                        alliTmp.admins.Add(jug2);
                    }

                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Alianza> getAllAlianzas()
        {
            //List<Alianza> alianzas = new List<Alianza>();
            //try
            //{
            //    List<Entities.Alianza> alliTmp = ctx.Alianza.ToList();
            //    foreach (Entities.Alianza item in alliTmp)
            //    {
            //        Alianza all = new Alianza(item.nombre, item.miembros, item.admins, item.descripcion, item.foto);
            //        alianzas.Add(all);
            //    }
            //    return alianzas;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            throw new NotImplementedException();
        }

        public Alianza getAlianza(int id)
        {
            throw new NotImplementedException();
        }
    }
}
