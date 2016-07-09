using BLayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GameBuildPortal.Controllers;


namespace GameBuildPortal.ControllersAdminApi
{
    public class ProductoController : ApiController
    {

        public static IAdmin blHandler;
        // GET: Producto
        public ProductoController()
        {
            blHandler = WebApiConfig.BuilderService(Tenantcontroller.tenant);
        }

        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return blHandler.getAllProductos();
        }
    }
}