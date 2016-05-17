using BLayer.Interfaces;
using DALayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLayer.Admin
{
    public class GameBuilderController : IGameBuilder
    {
        private IApi builder;
        private String tenantId = null;
        public GameBuilderController(string tId, IApi gc) {
            builder = gc;
            builder.setTenant(tId);
        }
        public void createRecurso(string name, string description, byte[] photo)
        {
            
            builder.getRecursoHandler().CreateRecurso(new Recurso(name, description, photo));
        }
    }
}
