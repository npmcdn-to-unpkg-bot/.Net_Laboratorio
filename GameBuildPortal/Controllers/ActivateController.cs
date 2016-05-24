using GameBuildPortal.Models;
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
        public ActionResult Create(int usuario, int password, int token)
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
