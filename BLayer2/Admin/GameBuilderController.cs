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

        //RECURSOS
        public List<Recurso> getAllRecursos()
        {
            return builder.getRecursoHandler().getAllRecursos();
        }

        public Recurso getRecurso(Guid id)
        {
            return builder.getRecursoHandler().getRecurso(id);
        }

        public void createRecurso(Recurso recurso)
        {
            builder.getRecursoHandler().createRecurso(recurso);
        }

        public void updateRecurso(Recurso recurso)
        {
            builder.getRecursoHandler().updateRecurso(recurso);
        }

        public void deleteRecurso(Recurso recurso)
        {
            builder.getRecursoHandler().deleteRecurso(recurso);
        }

        //MAPAS
        public List<MapaNode> getAllMapas()
        {
            return builder.getMapaNodeHandler().getAllMapas();
        }
    }
}
