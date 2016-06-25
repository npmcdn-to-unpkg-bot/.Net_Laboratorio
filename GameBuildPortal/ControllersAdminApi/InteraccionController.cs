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
    public class InteraccionController : ApiController
    {
        public static IAdmin blHandler;

        public InteraccionController()
        {
            blHandler = WebApiConfig.BuilderService(Tenantcontroller.tenant);
        }
        //QUEDA PARA HABILITAR CUANDO ESTEN LAS INTERACCIONES
        //[HttpGet]
        //public Interaccion Get(int id)
        //{
        //    Interaccion interaccion = blHandler.getInteraccion(id);
        //    if (interaccion == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    return interaccion;
        //}

        //[HttpGet]
        //public IEnumerable<Interaccion> Get()
        //{
        //    return blHandler.getAllInteracciones();
        //}

        //[HttpPut]
        //public HttpResponseMessage Put(int id, Interaccion interaccion)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    if (id != interaccion.id)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    try
        //    {
        //        blHandler.updateInteraccion(interaccion);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //[HttpPost]
        //public HttpResponseMessage Post(Interaccion interaccion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        blHandler.createInteraccion(interaccion);

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, interaccion);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { controller = "Admin" }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}

        //[HttpDelete]
        //public HttpResponseMessage Delete(int id)
        //{
        //    try
        //    {
        //        blHandler.deleteInteraccion(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}
    }
}
