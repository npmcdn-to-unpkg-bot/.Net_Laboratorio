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
    public class ReporteController : ApiController
    {
        public IFront blHandler;
        private IInteractionController interactionHandler;

        public ReporteController()
        {
            blHandler = WebApiConfig.FrontService(Tenantcontroller.getTenantName());
            interactionHandler = WebApiConfig.InteractionService(Tenantcontroller.getTenantName());
        }
        [HttpGet]
        public IntReporte Get(int id)
        {

            return interactionHandler.GetReportById(id);
        }
    }
}
