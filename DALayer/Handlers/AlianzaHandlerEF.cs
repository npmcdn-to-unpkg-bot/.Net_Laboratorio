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
                Entities.Jugador jug = new Entities.Jugador(item.nombre, item.apellido, item.foto, item.nickname,
                    item.nivel, item.experiencia);
                alli.miembros.Add(jug);
            }

            alli.admin = new Entities.Jugador(alliTmp.admin.nombre, alliTmp.admin.apellido, alliTmp.admin.foto,
                alliTmp.admin.nickname, alliTmp.admin.nivel, alliTmp.admin.experiencia);

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
                        Entities.Jugador jug = new Entities.Jugador(item.nombre, item.apellido, item.foto, item.nickname,
                    item.nivel, item.experiencia);
                        alliTmp.miembros.Add(jug);
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
            List<Alianza> alianzas = new List<Alianza>();
            try
            {
                List<Entities.Alianza> alliTmp = ctx.Alianza.ToList();
                foreach (Entities.Alianza item in alliTmp)
                {
                    Alianza all = getAlianza(item.id);
                    alianzas.Add(all);
                }
                return alianzas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Alianza getAlianza(int id)
        {
            try
            {
                var ali = (from c in ctx.Alianza
                           where c.id == id
                           select c).SingleOrDefault();

                List<Jugador> ljug = new List<Jugador>();
                foreach (var item in ali.miembros)
                {
                    var c = new SharedEntities.Entities.Jugador(item.Id, item.nombre, item.apellido, item.Email, item.UserName,
                                                       item.PasswordHash, item.foto, item.nickname, item.nivel, item.experiencia);
                    ljug.Add(c);
                }
                var adm = new SharedEntities.Entities.Jugador(ali.admin.Id, ali.admin.nombre, ali.admin.apellido, ali.admin.Email, ali.admin.UserName,
                                                       ali.admin.PasswordHash, ali.admin.foto, ali.admin.nickname, ali.admin.nivel, ali.admin.experiencia);
                                                
                Alianza alianza = new Alianza(ali.id, ali.nombre, ljug, adm, ali.descripcion, ali.foto);
                return alianza;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
