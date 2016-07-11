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
    public class ReporteRegistroController : ApiController
    {
        // GET: api/ReporteRegistro
        public IEnumerable<object> Get()
        {
            IAdmin builder = WebApiConfig.BuilderService(Tenantcontroller.getTenantName());
            List<object> res = builder.getReporteRegistro();
            return res;
        }
    }
}
