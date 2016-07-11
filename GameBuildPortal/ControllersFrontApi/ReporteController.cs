using BLayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameBuildPortal.ControllersFrontApi
{
    public class ReporteController : ApiController
    {
        public static IFront blHandler;
        private IInteractionController interactionHandler;

        public ReporteController()
        {
            blHandler = WebApiConfig.FrontService(null);
            interactionHandler = WebApiConfig.InteractionService(null);
        }
        [HttpGet]
        public IntReporte Get(int id)
        {

            return interactionHandler.GetReportById(id);
        }
    }
}
