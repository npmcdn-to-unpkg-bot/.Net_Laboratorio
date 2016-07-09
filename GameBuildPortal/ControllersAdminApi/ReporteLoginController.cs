using BLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameBuildPortal.Controllers;

namespace GameBuildPortal.ControllersAdminApi
{
    public class ReporteLoginController : ApiController
    {
        // GET: api/ReporteLogin
        public IEnumerable<object> Get()
        {
            IAdmin builder = WebApiConfig.BuilderService(Tenantcontroller.tenant);
            List<object> res = builder.getReporteLogin();
            return res;
        }
    }
}
