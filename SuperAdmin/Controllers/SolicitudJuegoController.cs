using BLayer.SuperAdmin;
using SharedEntities.Entities;
using SuperAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

            return RedirectToAction("Create");
            
        }

        
    }
}
