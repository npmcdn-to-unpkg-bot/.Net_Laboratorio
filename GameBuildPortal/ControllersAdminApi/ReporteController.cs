using BLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameBuildPortal.ControllersAdminApi
{
    public class ReporteController : ApiController
    {
        // GET: api/Reporte
        public IEnumerable<string> Get()
        {
            IAdmin builder = WebApiConfig.BuilderService("");
            object [] result  = builder.getReporteLogin();
            return new string[] { "value1", "value2" };
        }

        // GET: api/Reporte/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reporte
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Reporte/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reporte/5
        public void Delete(int id)
        {
        }
    }
}
