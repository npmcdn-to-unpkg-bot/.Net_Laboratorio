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
        Recurso createRecurso(Recurso recurso);
        void deleteRecurso(Recurso recurso);
        Recurso updateRecurso(Recurso recurso);
        Recurso getRecurso(string nombre);
    }
}
