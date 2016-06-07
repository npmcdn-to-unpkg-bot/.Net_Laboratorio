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
    public class InvestigacionController : ApiController
    {
        public static IAdmin blHandler;

        public InvestigacionController()
        {
            blHandler = WebApiConfig.BuilderService(null);
        }

        [HttpGet]
        public Investigacion Get(int id)
        {
            Investigacion investigacion = blHandler.getInvestigacion(id);
            if (investigacion == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return investigacion;
        }

        [HttpGet]
        public IEnumerable<Investigacion> Get()
        {
            return blHandler.getAllInvestigaciones();
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Investigacion investigacion)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != investigacion.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateInvestigacion(investigacion);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(Investigacion investigacion)
        {
            if (ModelState.IsValid)
            {
                int id = blHandler.createInvestigacion(investigacion);

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
                blHandler.deleteInvestigacion(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
