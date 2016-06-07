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
    public class DestacamentoController : ApiController
    {
        public static IAdmin blHandler;

        public DestacamentoController()
        {
            blHandler = WebApiConfig.BuilderService(null);
        }

        [HttpGet]
        public Destacamento Get(int id)
        {
            Destacamento destacamento = blHandler.getDestacamento(id);
            if (destacamento == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return destacamento;
        }

        [HttpGet]
        public IEnumerable<Destacamento> Get()
        {
            return blHandler.getAllDestacamentos();
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Destacamento destacamento)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != destacamento.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateDestacamento(destacamento);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(Destacamento destacamento)
        {
            if (ModelState.IsValid)
            {
                int id = blHandler.createDestacamento(destacamento);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, id);
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
                blHandler.deleteDestacamento(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
