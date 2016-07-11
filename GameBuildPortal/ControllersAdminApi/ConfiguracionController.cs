using BLayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameBuildPortal.Controllers;


namespace GameBuildPortal.ControllersAdminApi
{
    public class ConfiguracionController : ApiController
    {
        public IAdmin blHandler;

        public ConfiguracionController()
        {
            blHandler = WebApiConfig.BuilderService(Tenantcontroller.getTenantName());
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
