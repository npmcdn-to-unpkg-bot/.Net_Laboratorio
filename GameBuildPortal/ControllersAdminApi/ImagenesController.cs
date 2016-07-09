using BLayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace GameBuildPortal.ControllersAdminApi
{
    public class ImagenesController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                string name = "";
                Random rand = new Random();
                int randName = rand.Next(1, 99999);
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/Content/upload/" + randName + "_" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    name = randName + "_" + postedFile.FileName;
                }

                return Request.CreateResponse(HttpStatusCode.Created, name);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
