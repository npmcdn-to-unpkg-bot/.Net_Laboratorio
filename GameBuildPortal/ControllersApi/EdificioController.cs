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
    public class EdificioController : ApiController
    {
        public static IGameBuilder blHandler;

        public EdificioController()
        {
            blHandler = WebApiConfig.blHandler;
        }

        [HttpGet]
        public Edificio Get(int id)
        {
            Edificio edificio = blHandler.getEdificio(id);
            if (edificio == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return edificio;
        }

        [HttpGet]
        public IEnumerable<Edificio> Get()
        {
            return blHandler.getAllEdificios();
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Edificio edificio)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != edificio.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateEdificio(edificio);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(Edificio edificio)
        {
            if (ModelState.IsValid)
            {
                blHandler.createEdificio(edificio);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, edificio);
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
                blHandler.deleteEdificio(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
