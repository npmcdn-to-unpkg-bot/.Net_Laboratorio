using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameBuildPortal.Controllers;

namespace GameBuildPortal.Filters
{
    public class TenantFilter : FilterAttribute, IActionFilter
    {
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
                Tenantcontroller.tenant = tenant;
            }
        }
    }
}