using BLayer.Interfaces;
using DALayer;
using DALayer.Entities;
using DALayer.Interfaces;
using GameBuildPortal.Modules;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameBuildPortal.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ApplicationUserManager _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                string id = User.Identity.GetUserId();
                UsuarioHelper UHelper = new UsuarioHelper(_userManager, id);
                if (!UHelper.isAdmin)
                {
                   
                    WebApiConfig.BuilderService(null).registerLogin(id);
                    SharedEntities.Entities.Configuracion ui = WebApiConfig.BuilderService(null).getUi(1);

                    return View(ui);
                }
            }

            return RedirectToAction("Home", "Home");
        }

        public ActionResult Home()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    ApplicationUserManager _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //    string id = User.Identity.GetUserId();
            //    UsuarioHelper UHelper = new UsuarioHelper(_userManager, id);

            //    if (!UHelper.isAdmin)
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else
            //    {
            //        return RedirectToAction("Index", "Admin");
            //    }
            //}

            return View();
        }
    }
}