using BLayer.SuperAdmin;
using SharedEntities.Entities;
using SuperAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SuperAdmin.Controllers
{
    public class SolicitudJuegoController : Controller
    {
        // GET: SolicitudJuego/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitudJuego/Create
        [HttpPost]
        public ActionResult Create(SolicitudJuegoModel sjm)
        { 
            SuperAdminController sac = new SuperAdminController();
            SolicitudJuego sol = new SolicitudJuego();
            sol.email = sjm.email;
            sol.expirationTime = sjm.expirationTime;
            sol.user = Guid.NewGuid().ToString();
            sol.password = Guid.NewGuid().ToString();
            sol.token = Guid.NewGuid().ToString();
            sac.createSolicitud(sol);
            string activateUrl = sac.getActivateURL(sol);
            sendEmail(sol.email, activateUrl);
            return RedirectToAction("Create");
            
        }
        public void sendEmail(string email, string content){
            String body = String.Format("<a href='atlas2.com{0}'>click here</a>", content);

            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            //TODO mover a configuracion
            client.Credentials = new System.Net.NetworkCredential("atlas2.no.reply@gmail.com", "Password1.");

            MailMessage mail = new MailMessage("atlas2.no.reply@gmail.com", email);
            mail.Subject = "Solicitud de creacion de juego";
            mail.Body = body;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }
        
    }
}
