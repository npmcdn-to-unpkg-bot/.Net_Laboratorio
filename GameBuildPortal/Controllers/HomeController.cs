using BLayer.Interfaces;
using DALayer.Interfaces;
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
            // Web API configuration and services
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration();
            String s = DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            IGameBuilder blHandler = container.Resolve<IGameBuilder>(new ParameterOverrides { { "tId", "orgasszm2o"+s }, { "IApi", container.Resolve<IApi>() } });
            blHandler.createRecurso("s"+s, "s", null);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}