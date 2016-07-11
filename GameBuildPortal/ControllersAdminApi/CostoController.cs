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
    public class CostoController : ApiController
    {
        public static IAdmin blHandler;

        public CostoController()
        {
            blHandler = WebApiConfig.BuilderService(Tenantcontroller.getTenantName());
        }

        [HttpGet]
        public Costo Get(int id)
        {
            Costo costo = blHandler.getCosto(id);
            if (costo == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return costo;
        }

        //[HttpGet]
        //public IEnumerable<Costo> Get()
        //{
        //    return blHandler.getAllCostos();
        //}

        [HttpPut]
        public HttpResponseMessage Put(int id, Costo costo)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != costo.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateCosto(costo);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(Costo costo)
        {
            if (ModelState.IsValid)
            {
                blHandler.createCosto(costo);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, costo);
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
                blHandler.deleteCosto(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}