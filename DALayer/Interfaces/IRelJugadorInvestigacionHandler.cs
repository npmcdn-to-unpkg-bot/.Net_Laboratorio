using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IRelJugadorInvestigacionHandler
    {
        void createRelJugadorInvestigacion(RelJugadorInvestigacion relacion);
        void deleteRelJugadorInvestigacion(int id);
        List<RelJugadorInvestigacion> getAllRelJugadorInvestigacion();
        void updateRelJugadorInvestigacion(RelJugadorInvestigacion relacion);
        RelJugadorInvestigacion getRelJugadorInvestigacion(int id);
    }
}
