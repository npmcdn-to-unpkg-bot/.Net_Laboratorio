using BLayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameBuildPortal.Controllers;

namespace GameBuildPortal.ControllersApi
{
    public class DependenciaController : ApiController
    {
        public IAdmin blHandler;

        public DependenciaController()
        {
            blHandler = WebApiConfig.BuilderService(Tenantcontroller.getTenantName()); 
        }

        [HttpGet]
        public Dependencia Get(int id)
        {
            Dependencia dependencia = blHandler.getDependencia(id);
            if (dependencia == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return dependencia;
        }

        [HttpGet]
        public IEnumerable<Dependencia> Get()
        {
            return blHandler.getAllDependencias();
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Dependencia dependencia)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != dependencia.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateDependencia(dependencia);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(Dependencia dependencia)
        {
            if (ModelState.IsValid)
            {
                blHandler.createDependencia(dependencia);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, dependencia);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { controller = "Admin" }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                blHandler.deleteDependencia(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
