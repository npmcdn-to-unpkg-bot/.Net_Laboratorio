using BLayer.SuperAdmin;
using GameBuildPortal.Models;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameBuildPortal.Controllers
{
    public class ActivateController : Controller
    {
        // GET: Activate/Details/5
        public ActionResult Create(string usuario, string password, string token)
        {
            SuperAdminController sac = new SuperAdminController();
            SolicitudJuego sol = sac.getSolicitudByParam(usuario, password, token);
            if (sol.expirationTime.CompareTo(DateTime.Now) < 1)
            {
                return View();
            }
            else {
                return RedirectToAction("Expired");
            }
        }
        public ActionResult Expired()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ActivateGame g)
        {
            WebApiConfig.BuilderService(g.nombreJuego);
            return View();
        }
    }
}
