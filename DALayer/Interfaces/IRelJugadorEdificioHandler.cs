using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IRelJugadorEdificioHandler
    {
        void createRelJugadorEdificio(RelJugadorEdificio relacion);
        void deleteRelJugadorEdificio(int id);
        void updateRelJugadorEdificio(RelJugadorEdificio relacion);
        RelJugadorEdificio getRelJugadorEdificio(int id);
        List<RelJugadorEdificio> getEdificiosByColonia(int id);
    }
}
