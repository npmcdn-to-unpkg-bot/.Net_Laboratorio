using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLayer.Interfaces
{
    public interface IGameBuilder
    {
        List<Recurso> getAllRecursos();
        void createRecurso(Recurso recurso);
        void deleteRecurso(Recurso recurso);
        void updateRecurso(Recurso recurso);
        Recurso getRecurso(Guid id);

        List<MapaNode> getAllMapas();
    }
}
