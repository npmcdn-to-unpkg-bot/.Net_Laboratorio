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

        public GameBuilderController(string tId, IApi gc) {
            builder = gc;
            builder.setTenant(tId);
        }

        public List<Recurso> getAllRecursos()
        {
            return builder.getRecursoHandler().getAllRecursos();

            //GameBuilderController gbc = new GameBuilderController("nuevojuego", new DALayer.Api.EFApi());
            //return gbc.getAllRecursos();
        }

        public void createRecurso(string name, string description, byte[] photo)
        {
            builder.getRecursoHandler().createRecurso(new Recurso(name, description, photo));
        }
    }
}
