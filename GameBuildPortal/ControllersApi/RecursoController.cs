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
    public class RecursoController : ApiController
    {
        public static IGameBuilder blHandler;

        public RecursoController()
        {
            blHandler = WebApiConfig.blHandler;
        }

        public Recurso Get(int id)
        {
            //return blHandler.getRecurso(idEmployee);
            throw new NotImplementedException();
        }

        public IEnumerable<Recurso> Get()
        {
            return blHandler.getAllRecursos();
        }

        public bool Put(int id, [FromBody]string value)
        {
            //blHandler.updateRecurso(value); 
            throw new NotImplementedException();
        }

        public bool Post(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
            //blHandler.deleteRecurso(id);
            //return true;
        }
    }
}
