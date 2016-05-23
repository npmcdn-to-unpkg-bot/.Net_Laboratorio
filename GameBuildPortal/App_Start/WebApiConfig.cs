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
        public static IGameBuilder blHandler;
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration();
            blHandler = container.Resolve<IGameBuilder>(new ParameterOverrides { { "tId", "olgame5" },{ "IApi", container.Resolve<IApi>() } });
            //container.Resolve<IGameBuilder>(new ParameterOverrides { { "tId", "orgame2" }, { "IApi", container.Resolve<IApi>() } });

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "admin/api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
