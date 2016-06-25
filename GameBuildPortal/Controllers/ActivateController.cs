using BLayer.SuperAdmin;
using GameBuildPortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace GameBuildPortal.Controllers
{
    public class ActivateController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ActivateController()
        {
        }

        public ActivateController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        // GET: Activate/Details/5
        public ActionResult Create(string usuario, string password, string token)
        {
            SuperAdminController sac = new SuperAdminController();
            SolicitudJuego sol = sac.getSolicitudByParam(usuario, password, token);
            if (sol != null && sol.expirationTime.CompareTo(DateTime.Now) >= 0)
            {
                return View();
            }
            else {
                return RedirectToAction("Expired");
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Expired()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Create(ActivateGame g)
        {
            //validar si juego existe
            //si juego no existe 
            //creo el tenant
            WebApiConfig.BuilderService(g.nombreJuego);
            Tenantcontroller.tenant = g.nombreJuego;
            Tenantcontroller.game = g;
            return RedirectToAction("ProcessUser", "Activate");
}

        public ActionResult ProcessUser()
        {
            return Task.Run(RedirectToRealAction).Result;
        }

        public async Task<ActionResult> RedirectToRealAction()
        {
            ActivateGame g = Tenantcontroller.game;
            DALayer.Entities.Usuario us = new DALayer.Entities.Admin { UserName = g.Email, Email = g.Email, apellido = g.apellido, telefono = g.teléfono, CreatedDate = DateTime.Now };
            HttpContext.GetOwinContext().Get<ActivateController>();
            var result = await UserManager.CreateAsync(us, g.Password);
            if (result.Succeeded)
            {
                await SignInManager.SignInAsync(us, isPersistent: false, rememberBrowser: false);
                Response.BufferOutput = true;
                return Redirect("http://"+Tenantcontroller.tenant + ".moskters.com/admin/index");


                //agregar configuraciones por defecto
                Configuracion conf = new Configuracion(0, "", g.nombreJuego, g.nombreJuego, null, null);
                WebApiConfig.BuilderService(null).createConf(conf);

                return RedirectToAction("Index", "Admin");

            }

            AddErrors(result);
            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
