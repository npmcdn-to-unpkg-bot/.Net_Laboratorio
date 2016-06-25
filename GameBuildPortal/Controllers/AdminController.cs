using DALayer.Entities;
using GameBuildPortal.Models;
using GameBuildPortal.Modules;
using GameBuildPortal.Filters;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameBuildPortal.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Login()
        {
            SharedEntities.Entities.Configuracion conf = WebApiConfig.BuilderService(null).getConfiguracion(1);

            LayoutViewModel model = new LayoutViewModel();
            model.Configuracion = conf;

            return View(model);
        }

        public ActionResult Index()
        {
            ApplicationUserManager _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            string id = User.Identity.GetUserId();
            UsuarioHelper UHelper = new UsuarioHelper(_userManager, id);

            if (UHelper.isAdmin)
            {
                SharedEntities.Entities.Configuracion conf = WebApiConfig.BuilderService(null).getConfiguracion(1);

                LayoutViewModel model = new LayoutViewModel();
                model.Configuracion = conf;

                return View(model);
            }

            return RedirectToAction("Login", "Admin");
        }
    }
}