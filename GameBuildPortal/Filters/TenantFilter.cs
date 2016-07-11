using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameBuildPortal.Controllers;
using System.Web.SessionState;

namespace GameBuildPortal.Filters
{
    public class TenantFilter : FilterAttribute, IActionFilter
    {
        public HttpSessionState Session { get; }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Do nothing
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            String tenant = null;
            string host = HttpContext.Current.Request.Url.Host;
            var nodes = host.Split('.');
            int startNode = 0;
            if (nodes[0] == "www") startNode = 1;
            if (nodes[startNode] != "moskters" && nodes[startNode] != "localhost")
            {
                tenant = nodes[startNode];
                //filterContext.RouteData.Values.Add("tenant", tenant);
              //  System.Web.HttpContext.Current.Session["tenant"] = tenant;
               // Tenantcontroller.setTenant(null);
            }
        }

        /* protected override void OnActionExecuting(ActionExecutingContext filterContext) {
             filterContext.RouteData.Values.Add("test", "TESTING");
             base.OnActionExecuting(filterContext);
         }
         public ActionResult Index() {
             ViewData["Message"] = RouteData.Values["test"]; return View();
         }*/
    }
}