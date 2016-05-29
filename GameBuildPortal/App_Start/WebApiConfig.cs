using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using BLayer.Interfaces;
using DALayer.Interfaces;

namespace GameBuildPortal
{
    public static class WebApiConfig
    {
        private static IUnityContainer container = null;
        public static string tenant = "FirstOnlinetenant2";
        public static void Register(HttpConfiguration config)
        {
            if (container == null)
            {
                // Web API configuration and services
                container = new UnityContainer();
                container.LoadConfiguration();

                // Web API routes
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "admin/api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
        }
       
        public static IGameBuilder BuilderService(string tenant) {
            tenant = WebApiConfig.tenant;
            return container.Resolve<IGameBuilder>(new ParameterOverrides { { "tId", tenant }, { "IApi", container.Resolve<IApi>() } });
        }
    }
}
