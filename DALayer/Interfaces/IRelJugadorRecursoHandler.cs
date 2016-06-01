using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IRelJugadorRecursoHandler
    {
        void createRelJugadorRecurso(RelJugadorRecurso relacion);
        void deleteRelJugadorRecurso(int id);
        void updateRelJugadorRecurso(RelJugadorRecurso relacion);
        RelJugadorRecurso getRelJugadorRecurso(int id);
        List<RelJugadorRecurso> getRecursosByColonia(int id);
        void calcularRecursosByIdCol(int id);
    }
}
