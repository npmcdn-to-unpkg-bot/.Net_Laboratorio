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
    public class ProduceController : ApiController
    {
        public static IAdmin blHandler;

        public ProduceController()
        {
            blHandler = WebApiConfig.BuilderService(Tenantcontroller.tenant);
        }

        [HttpGet]
        public Produce Get(int id)
        {
            Produce produce = blHandler.getProduce(id);
            if (produce == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return produce;
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Produce produce)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != produce.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateProduce(produce);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(Produce produce)
        {
            if (ModelState.IsValid)
            {
                blHandler.createProduce(produce);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, produce);
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
                blHandler.deleteProduce(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}