using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameBuildPortal.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Web.SessionState;

namespace GameBuildPortal.Controllers
{
    public class Tenantcontroller
    {
        public static String tenant;
        public static ActivateGame game;
        public static HttpSessionState Session { get; }

        public static void setTenant(string nombre)
        {
            Tenantcontroller.tenant = nombre;
        }

        public static String getTenantName()
        {
            if (Tenantcontroller.tenant != null)
                return Tenantcontroller.tenant;
            String result;
            string host = HttpContext.Current.Request.Url.Host;
            var nodes = host.Split('.');
            int startNode = 0;
            if (nodes[0] == "www") startNode = 1;
            if (nodes[startNode] != "moskters" && nodes[startNode] != "localhost")
            {
                result = nodes[startNode];
                Tenantcontroller.setTenant(null);
                return result;
                
            }
            return null;
        }


    }
}