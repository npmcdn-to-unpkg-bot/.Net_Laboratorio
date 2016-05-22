using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLayer.Interfaces
{
    public interface IGameBuilder
    {
        // RECURSO
        List<Recurso> getAllRecursos();
        void createRecurso(Recurso recurso);
        void deleteRecurso(Recurso recurso);
        void updateRecurso(Recurso recurso);
        Recurso getRecurso(int id);

        //MAPA
        List<MapaNode> getAllMapas();
    }
}
