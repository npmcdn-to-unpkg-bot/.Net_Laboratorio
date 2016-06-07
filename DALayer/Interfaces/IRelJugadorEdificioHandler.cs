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
        void bajarNivel(int id);
        RelJugadorEdificio subirNivel(int id);
        RelJugadorEdificio getRelJugadorEdificio(int id);
        List<RelJugadorEdificio> getEdificiosByColonia(int id);
    }
}
