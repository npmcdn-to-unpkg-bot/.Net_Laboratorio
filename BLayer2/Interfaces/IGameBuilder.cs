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
        void createRecurso(string name, string description, byte[] photo);
    }
}
