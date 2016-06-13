using BLayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameBuildPortal.ControllersAdminApi
{
    public class ConfguracionController : ApiController
    {
        public static IAdmin blHandler;

        public ConfguracionController()
        {
            blHandler = WebApiConfig.BuilderService(null);
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            Configuracion conf = blHandler.getConfiguracion(id);
            if (conf == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, conf);
        }

        [HttpPost]
        public HttpResponseMessage Post(Configuracion conf)
        {
            if (ModelState.IsValid)
            {
                blHandler.createConf(conf);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, conf);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { controller = "Admin" }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Configuracion conf)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != conf.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateConf(conf);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
