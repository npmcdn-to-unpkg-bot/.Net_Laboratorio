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

        // ALIANZA
        List<Alianza> getAllAlianzas();
        void createAlianza(Alianza alianza);
        void deleteAlianza(int id);
        void updateAlianza(Alianza alianza);
        Alianza getAlianza(int id);

        // DEPENDENCIA
        List<Dependencia> getAllDependencias();
        void createDependencia(Dependencia dependencia);
        void deleteDependencia(int id);
        void updateDependencia(Dependencia dependencia);
        Dependencia getDependencia(int id);

        // RELJUGADOREDIFICIO

        void createRelJugadorEdificio(RelJugadorEdificio relacion);
        void deleteRelJugadorEdificio(int id);
        void updateRelJugadorEdificio(RelJugadorEdificio relacion);
        RelJugadorEdificio getRelJugadorEdificio(int id);
        List<RelJugadorEdificio> getEdificiosByColonia(int id);

        //RELJUGADORINVESTIGACION

        void createRelJugadorInvestigacion(RelJugadorInvestigacion relacion);
        void deleteRelJugadorInvestigacion(int id);
        void updateRelJugadorInvestigacion(RelJugadorInvestigacion relacion);
        RelJugadorInvestigacion getRelJugadorInvestigacion(int id);
        List<RelJugadorInvestigacion> getInvestigacionesByColonia(int id);

        //RELJUGADORMAPA

        void createRelJugadorMapa(RelJugadorMapa r);
        void deleteRelJugadorMapa(int id);
        void updateRelJugadorMapa(RelJugadorMapa r);
        RelJugadorMapa getRelJugadorMapa(int id);
        List<RelJugadorMapa> getMapasByJugador(Jugador j);

        //RELJUGADORRECURSO

        void createRelJugadorRecurso(RelJugadorRecurso relacion);
        void deleteRelJugadorRecurso(int id);
        void updateRelJugadorRecurso(RelJugadorRecurso relacion);
        RelJugadorRecurso getRelJugadorRecurso(int id);
        List<RelJugadorRecurso> getRecursosByColonia(int id);

        //RELJUGADORDESTACAMENTO

        void createRelJugadorDestacamento(RelJugadorDestacamento relacion);
        void deleteRelJugadorDestacamento(int id);
        void updateRelJugadorDestacamento(RelJugadorDestacamento relacion);
        RelJugadorDestacamento getRelJugadorDestacamento(int id);
        List<RelJugadorDestacamento> getDestacamentosByColonia(int id);
    }
}
