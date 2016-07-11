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
    public class RecursoController : ApiController
    {
        public IAdmin blHandler;

        public RecursoController()
        {
            blHandler = WebApiConfig.BuilderService(Tenantcontroller.getTenantName());
        }

        [HttpGet]
        public Recurso Get(int id)
        {
            Recurso recurso = blHandler.getRecurso(id);
            if (recurso == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return recurso;
        }

        [HttpGet]
        public IEnumerable<Recurso> Get()
        {
            return blHandler.getAllRecursos();
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Recurso recurso)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != recurso.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateRecurso(recurso);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                blHandler.createRecurso(recurso);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, recurso);
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
                blHandler.deleteRecurso(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
