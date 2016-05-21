using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IRecursoHandler
    {
        Recurso createRecurso(Recurso rec);
        void deleteRecurso(Recurso rec);
        Recurso updateRecurso(Recurso rec);
        List<Recurso> getAllRecursos();
        Recurso getRecurso(string nombre);
    }
}
