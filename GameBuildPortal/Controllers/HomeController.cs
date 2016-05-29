using BLayer.Interfaces;
using DALayer;
using DALayer.Entities;
using DALayer.Interfaces;
using GameBuildPortal.Modules;
using Microsoft.AspNet.Identity;
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ApplicationUserManager _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            string id = User.Identity.GetUserId(); 
            UsuarioHelper UHelper = new UsuarioHelper(_userManager, id);
            Admin adm;
            Jugador jug;
            if (UHelper.isAdmin)
            {
                adm = UHelper.getAdmin();
            }
            else {
                jug = UHelper.getJugador();
            }

            return View();
        }
    }
}