using BLayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameBuildPortal.ControllersApi
{
    public class RecursoController : ApiController
    {
        public static IGameBuilder blHandler;

        public RecursoController()
        {
            blHandler = WebApiConfig.blHandler;
        }

        [HttpGet]
        public Recurso Get(string nombre)
        {
            Recurso recurso = blHandler.getRecurso(nombre);
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
        public HttpResponseMessage Put(string nombre, Recurso recurso)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (nombre != recurso.nombre)
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
                response.Headers.Location = new Uri(Url.Link("RecursoApi", new { controller = "Admin" }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(string nombre)
        {
            Recurso recurso = blHandler.getRecurso(nombre);
            if (recurso == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            
            try
            {
                blHandler.deleteRecurso(recurso);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, recurso);
        }
    }
}
