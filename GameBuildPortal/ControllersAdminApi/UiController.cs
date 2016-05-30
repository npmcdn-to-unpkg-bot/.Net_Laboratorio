using BLayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameBuildPortal.ControllersAdminApi
{
    public class UiController : ApiController
    {
        public static IAdmin blHandler;

        public UiController()
        {
            blHandler = WebApiConfig.BuilderService(null);
        }

        [HttpPost]
        public HttpResponseMessage Post(Ui ui)
        {
            if (ModelState.IsValid)
            {
                blHandler.createUi(ui);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ui);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { controller = "Admin" }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Ui ui)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != ui.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                blHandler.updateUi(ui);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
