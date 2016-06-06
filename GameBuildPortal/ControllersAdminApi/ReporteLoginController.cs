using BLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameBuildPortal.ControllersAdminApi
{
    public class ReporteLoginController : ApiController
    {
        // GET: api/ReporteLogin
        public IEnumerable<object> Get()
        {
            IAdmin builder = WebApiConfig.BuilderService(null);
            List<object> res = builder.getReporteLogin();
            return res;
        }
    }
}
