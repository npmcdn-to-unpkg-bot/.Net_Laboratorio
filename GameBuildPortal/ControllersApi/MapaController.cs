using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLayer.Interfaces;
using SharedEntities.Entities;

namespace GameBuildPortal.ControllersApi
{
    public class MapaController : ApiController
    {
        public static IGameBuilder blHandler;

        public MapaController()
        {
            blHandler = WebApiConfig.blHandler;
        }

        //[HttpGet]
        //public Mapa Get(Guid id)
        //{
        //    Mapa recurso = blHandler.getRecurso(id);
        //    if (recurso == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    return recurso;
        //}

        [HttpGet]
        public IEnumerable<MapaNode> Get()
        {
            return blHandler.getAllMapas();
        }

        //[HttpPut]
        //public HttpResponseMessage Put(Guid id, Recurso recurso)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    if (id != recurso.id)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    try
        //    {
        //        blHandler.updateRecurso(recurso);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //[HttpPost]
        //public HttpResponseMessage Post(Recurso recurso)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        blHandler.createRecurso(recurso);

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, recurso);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { controller = "Admin" }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}

        //[HttpDelete]
        //public HttpResponseMessage Delete(Guid id)
        //{
        //    Recurso recurso = blHandler.getRecurso(id);
        //    if (recurso == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    try
        //    {
        //        blHandler.deleteRecurso(recurso);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, recurso);
        //}
    }
}
