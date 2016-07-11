using BLayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameBuildPortal.Controllers;

namespace GameBuildPortal.ControllersFrontApi
{
    public class AlianzaController : ApiController
    {        
        public static IFront blHandler;
        
        public AlianzaController()
        {
            blHandler = WebApiConfig.FrontService(Tenantcontroller.getTenantName());
        }

        //[HttpGet]
        //public Alianza Get(int id)
        //{
        //    Alianza alianza = blHandler.getAlianza(id);
        //    if (alianza == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    return alianza;
        //}

        [HttpGet] // busscar por usuario
        public Alianza Get(string id)
        {
            Alianza alianza = blHandler.getAlianzaByAdministrador(id);
            return alianza;
        }

        [HttpGet]
        public IEnumerable<Alianza> Get()
        {
            return blHandler.getAllAlianzas();
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Alianza alianza)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != alianza.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateAlianza(alianza);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage Post(Alianza alianza)
        {
            if (ModelState.IsValid)
            {
                blHandler.createAlianza(alianza);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, alianza);
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
                blHandler.deleteAlianza(id);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}