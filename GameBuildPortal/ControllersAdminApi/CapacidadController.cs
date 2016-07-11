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
    public class CapacidadController : ApiController
    {
        public static IAdmin blHandler;

        public CapacidadController()
        {
            blHandler = WebApiConfig.BuilderService(Tenantcontroller.getTenantName());
        }

        [HttpGet]
        public Capacidad Get(int id)
        {
            Capacidad capacidad = blHandler.getCapacidad(id);
            if (capacidad == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return capacidad;
        }

        //[HttpGet]
        //public IEnumerable<Capacidad> Get()
        //{
        //    return blHandler.getAllCapacidades();
        //}

        [HttpPut]
        public HttpResponseMessage Put(int id, Capacidad capacidad)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != capacidad.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateCapacidad(capacidad);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(Capacidad capacidad)
        {
            if (ModelState.IsValid)
            {
                blHandler.createCapacidad(capacidad);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, capacidad);
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
                blHandler.deleteCapacidad(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}