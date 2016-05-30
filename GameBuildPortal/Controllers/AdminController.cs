using DALayer.Entities;
using GameBuildPortal.Modules;
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
            return View();
        }

        public ActionResult Index()
        {

            //ApplicationUserManager _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //string id = User.Identity.GetUserId();
            //UsuarioHelper UHelper = new UsuarioHelper(_userManager, id);
            //Admin adm;
            //Jugador jug;
            //if (UHelper.isAdmin)
            //{
            //    adm = UHelper.getAdmin();
            //}
            //else
            //{
            //    jug = UHelper.getJugador();
            //}

            return View();
        }
    }
}