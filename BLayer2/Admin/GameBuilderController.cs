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
        }

        public Recurso getRecurso(string nombre)
        {
            return builder.getRecursoHandler().getRecurso(nombre);
        }

        public Recurso createRecurso(Recurso recurso)
        {
            return builder.getRecursoHandler().createRecurso(recurso);
        }

        public Recurso updateRecurso(Recurso recurso)
        {
            return builder.getRecursoHandler().updateRecurso(recurso);
        }

        public void deleteRecurso(Recurso recurso)
        {
            builder.getRecursoHandler().deleteRecurso(recurso);
        }
    }
}
