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
        void createMapa(MapaNode mapa);
        MapaNode getMapa(int id);
        void deleteMapa(MapaNode mapa);
        void updateMapa(MapaNode mapa);

        //INVESTIGACION
        List<Investigacion> getAllInvestigaciones();
        void createInvestigacion(Investigacion investigacion);
        void deleteInvestigacion(Investigacion investigacion);
        void updateInvestigacion(Investigacion investigacion);
        Investigacion getInvestigacion(int id);
    }
}
