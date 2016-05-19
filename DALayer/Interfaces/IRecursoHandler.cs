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
        void CreateRecurso(Recurso rec);
        void DeleteRecurso(string nombreTmp);
        void UpdateRecurso(Recurso rec);
        List<Recurso> GetAllRecursos(); 
    }
}
