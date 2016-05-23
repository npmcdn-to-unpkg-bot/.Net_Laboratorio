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
        void deleteRecurso(int id);
        void updateRecurso(Recurso recurso);
        Recurso getRecurso(int id);

        //MAPA
        List<MapaNode> getAllMapas();
        void createMapa(MapaNode mapa);
        MapaNode getMapa(int id);
        void deleteMapa(int id);
        void updateMapa(MapaNode mapa);

        //INVESTIGACION
        List<Investigacion> getAllInvestigaciones();
        void createInvestigacion(Investigacion investigacion);
        void deleteInvestigacion(int id);
        void updateInvestigacion(Investigacion investigacion);
        Investigacion getInvestigacion(int id);

        // DESTACAMENTO
        List<Destacamento> getAllDestacamentos();
        void createDestacamento(Destacamento destacamento);
        void deleteDestacamento(int id);
        void updateDestacamento(Destacamento destacamento);
        Destacamento getDestacamento(int id);

        // EDIFICIO
        List<Edificio> getAllEdificios();
        void createEdificio(Edificio edificio);
        void deleteEdificio(int id);
        void updateEdificio(Edificio edificio);
        Edificio getEdificio(int id);
    }
}
