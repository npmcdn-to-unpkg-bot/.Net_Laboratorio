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
    class SolicitudJuegoHandlerEF : ISolicitudJuegoHandler
    {                
        AdminContext ctx;
        public SolicitudJuegoHandlerEF(AdminContext ac)
        {
            ctx = ac;
        }
        public void createSolicitudJuego(SolicitudJuego soljuegoTmp)
        {

            Entities.SolicitudJuego sj = new Entities.SolicitudJuego();
            sj.email = soljuegoTmp.email;
            sj.password = soljuegoTmp.password;
            sj.token = soljuegoTmp.token;
            sj.user = soljuegoTmp.user;
            sj.expirationTime = soljuegoTmp.expirationTime;
            
            
            try
            {
                ctx.SolicitudJuego.Add(sj);

                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void deleteSolicitudJuego(int idTmp)
        {
            var sj = (from c in ctx.SolicitudJuego
                      where c.id == idTmp
                      select c).SingleOrDefault();
            try
            {
                ctx.SolicitudJuego.Remove(sj);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void updateSolicitudJuego(SolicitudJuego sj)
        {
            try
            {
                var sjTmp = ctx.SolicitudJuego
                    .Where(w => w.id == sj.id)
                    .SingleOrDefault();

                if (sjTmp != null)
                {
                    sjTmp.email = sj.email;
                    sjTmp.password = sj.password;
                    sjTmp.token = sj.token;
                    sjTmp.user = sj.user;
                    sjTmp.expirationTime = sj.expirationTime;

                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SolicitudJuego> getAllSolicitudes()
        {
            List<SolicitudJuego> solicitudes = new List<SolicitudJuego>();
            try
            {
                List<Entities.SolicitudJuego> sjTmp = ctx.SolicitudJuego.ToList();
                foreach (Entities.SolicitudJuego item in sjTmp)
                {
                    SolicitudJuego sol = new SolicitudJuego(item.id, item.email, item.user, item.password, item.token, item.expirationTime);
                    solicitudes.Add(sol);
                }
                return solicitudes;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public SolicitudJuego getSolicitudJuego(int id)
        {
            throw new NotImplementedException();
        }
    }
}
