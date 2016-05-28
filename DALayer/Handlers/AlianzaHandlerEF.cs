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
            //    try
            //    {
            //        var ali = (from c in ctx.Alianza
            //                   where c.id == id
            //                   select c).SingleOrDefault();

            //        Alianza alianza = new Alianza(ali.id, ali.nombre, ali.miembros, ali.admins ,ali.descripcion, ali.foto);
            //        return alianza;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
            throw new NotImplementedException();
        }
    }
}
