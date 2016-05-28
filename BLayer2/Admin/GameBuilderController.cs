using BLayer.Interfaces;
using DALayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLayer.Admin
{
    public class GameBuilderController : IGameBuilder
    {
        private IApi builder;

        public GameBuilderController(string tId, IApi gc) {
            builder = gc;
            tId = tId.Replace(" ", "_");
            builder.setTenant(tId);
        }
        //TENANT
        public bool existGame(string gameName) {
            return builder.getTenantHandler().tenantExist(gameName);
        }
        //RECURSOS
        public List<Recurso> getAllRecursos()
        {
            return builder.getRecursoHandler().getAllRecursos();
        }

        public Recurso getRecurso(int id)
        {
            return builder.getRecursoHandler().getRecurso(id);
        }

        public void createRecurso(Recurso recurso)
        {
            builder.getRecursoHandler().createRecurso(recurso);
        }

        public void updateRecurso(Recurso recurso)
        {
            builder.getRecursoHandler().updateRecurso(recurso);
        }

        public void deleteRecurso(int id)
        {
            builder.getRecursoHandler().deleteRecurso(id);
        }

        //MAPAS
        public List<MapaNode> getAllMapas()
        {
            return builder.getMapaNodeHandler().getAllMapas();
        }
        public MapaNode getMapa(int id)
        {
            return builder.getMapaNodeHandler().getMapa(id);
        }

        public void createMapa(MapaNode mapa)
        {
            builder.getMapaNodeHandler().CreateMapa(mapa);
        }

        public void deleteMapa(int id)
        {
            builder.getMapaNodeHandler().DeleteMapa(id);
        }

        public void updateMapa(MapaNode mapa)
        {
            builder.getMapaNodeHandler().UpdateMapa(mapa);
        }

        //INVESTIGACION
        public List<Investigacion> getAllInvestigaciones()
        {
            return builder.getInvestigacionHandler().getAllInvestigaciones();
        }

        public Investigacion getInvestigacion(int id)
        {
            return builder.getInvestigacionHandler().getInvestigacion(id);
        }

        public void createInvestigacion(Investigacion investigacion)
        {
            builder.getInvestigacionHandler().createInvestigacion(investigacion);
        }

        public void updateInvestigacion(Investigacion investigacion)
        {
            builder.getInvestigacionHandler().updateInvestigacion(investigacion);
        }

        public void deleteInvestigacion(int id)
        {
            builder.getInvestigacionHandler().deleteInvestigacion(id);
        }

        //DESTACAMENTOS
        public List<Destacamento> getAllDestacamentos()
        {
            return builder.getUnidadHandler().getAllDestacamentos();
        }

        public Destacamento getDestacamento(int id)
        {
            return builder.getUnidadHandler().getDestacamento(id);
        }

        public void createDestacamento(Destacamento destacamento)
        {
            builder.getUnidadHandler().createDestacamento(destacamento);
        }

        public void updateDestacamento(Destacamento destacamento)
        {
            builder.getUnidadHandler().updateDestacamento(destacamento);
        }

        public void deleteDestacamento(int id)
        {
            builder.getUnidadHandler().deleteDestacamento(id);
        }

        //EDIFICIOS
        public List<Edificio> getAllEdificios()
        {
            return builder.getUnidadHandler().getAllEdificios();
        }

        public Edificio getEdificio(int id)
        {
            return builder.getUnidadHandler().getEdificio(id);
        }

        public void createEdificio(Edificio edificio)
        {
            builder.getUnidadHandler().createEdificio(edificio);
        }

        public void updateEdificio(Edificio edificio)
        {
            builder.getUnidadHandler().updateEdificio(edificio);
        }

        public void deleteEdificio(int id)
        {
            builder.getUnidadHandler().deleteEdificio(id);
        }

        //ALIANZA
        public List<Alianza> getAllAlianzas()
        {
            return builder.getAlianzaHandler().getAllAlianzas();
        }

        public Alianza getAlianza(int id)
        {
            return builder.getAlianzaHandler().getAlianza(id);
        }

        public void createAlianza(Alianza alianza)
        {
            builder.getAlianzaHandler().createAlianza(alianza);
        }

        public void updateAlianza(Alianza alianza)
        {
            builder.getAlianzaHandler().updateAlianza(alianza);
        }

        public void deleteAlianza(int id)
        {
//            builder.getAlianzaHandler().deleteAlianza(id);
        }

        //DEPENDENCIA
        public List<Dependencia> getAllDependencias()
        {
            return builder.getDependenciaHandler().getAllDependencias();
        }

        public Dependencia getDependencia(int id)
        {
            return builder.getDependenciaHandler().getDependencia(id);
        }

        public void createDependencia(Dependencia dependencia)
        {
            builder.getDependenciaHandler().createDependencia(dependencia);
        }

        public void updateDependencia(Dependencia dependencia)
        {
            builder.getDependenciaHandler().updateDependencia(dependencia);
        }

        public void deleteDependencia(int id)
        {
            builder.getDependenciaHandler().deleteDependencia(id);
        }

        //RELJUGADORRECURSOS

        public RelJugadorRecurso getRelJugadorRecurso(int id)
        {
            return builder.getRelJugadorRecursoHandler().getRelJugadorRecurso(id);
        }

        public void createRelJugadorRecurso(RelJugadorRecurso reljugadorrecurso)
        {
            builder.getRelJugadorRecursoHandler().createRelJugadorRecurso(reljugadorrecurso);
        }

        public void updateRelJugadorRecurso(RelJugadorRecurso reljugadorrecurso)
        {
            builder.getRelJugadorRecursoHandler().updateRelJugadorRecurso(reljugadorrecurso);
        }

        public void deleteRelJugadorRecurso(int id)
        {
            builder.getRelJugadorRecursoHandler().deleteRelJugadorRecurso(id);
        }

        public List<RelJugadorRecurso> getRecursosByColonia(int id)
        {
            return builder.getRelJugadorRecursoHandler().getRecursosByColonia(id);
        }

        //RELJUGADOREDIFICIOS

        public RelJugadorEdificio getRelJugadorEdificio(int id)
        {
            return builder.getRelJugadorEdificioHandler().getRelJugadorEdificio(id);
        }

        public void createRelJugadorEdificio(RelJugadorEdificio reljugadoredificio)
        {
            builder.getRelJugadorEdificioHandler().createRelJugadorEdificio(reljugadoredificio);
        }

        public void updateRelJugadorEdificio(RelJugadorEdificio reljugadoredificio)
        {
            builder.getRelJugadorEdificioHandler().updateRelJugadorEdificio(reljugadoredificio);
        }

        public void deleteRelJugadorEdificio(int id)
        {
            builder.getRelJugadorEdificioHandler().deleteRelJugadorEdificio(id);
        }

        public List<RelJugadorEdificio> getEdficiosByColonia(int id)
        {
            return builder.getRelJugadorEdificioHandler().getEdificiosByColonia(id);
        }

        //RELJUGADORINVESTIGACION

        public RelJugadorInvestigacion getRelJugadorInvestigacion(int id)
        {
            return builder.getRelJugadorInvestigacionHandler().getRelJugadorInvestigacion(id);
        }

        public void createRelJugadorInvestigacion(RelJugadorInvestigacion reljugadorinvestigacion)
        {
            builder.getRelJugadorInvestigacionHandler().createRelJugadorInvestigacion(reljugadorinvestigacion);
        }

        public void updateRelInvestigacionEdificio(RelJugadorInvestigacion reljugadorinvestigacion)
        {
            builder.getRelJugadorInvestigacionHandler().updateRelJugadorInvestigacion(reljugadorinvestigacion);
        }

        public void deleteRelJugadorInvestigacion(int id)
        {
            builder.getRelJugadorInvestigacionHandler().deleteRelJugadorInvestigacion(id);
        }

        public List<RelJugadorInvestigacion> getInvestigacionByColonia(int id)
        {
            return builder.getRelJugadorInvestigacionHandler().getInvestigacionesByColonia(id);
        }

        //RELJUGADORMAPAS

        public RelJugadorMapa getRelJugadorMapa(int id)
        {
            return builder.getRelJugadorMapaHandler().getRelJugadorMapa(id);
        }

        public void createRelJugadorDestacamento(RelJugadorMapa reljugadormapa)
        {
            builder.getRelJugadorMapaHandler().createRelJugadorMapa(reljugadormapa);
        }

        public void updateRelJugadorMapa(RelJugadorMapa reljugadormapa)
        {
            builder.getRelJugadorMapaHandler().updateRelJugadorMapa(reljugadormapa);
        }

        public void deleteRelJugadorMapa(int id)
        {
            builder.getRelJugadorMapaHandler().deleteRelJugadorMapa(id);
        }

        public List<RelJugadorMapa> getMapasByJugador(Jugador jugador)
        {
            return builder.getRelJugadorMapaHandler().getMapasByJugador(jugador);
        }

        //RELJUGADORDESTACAMENTOS

        public RelJugadorDestacamento getRelJugadorDestacamento(int id)
        {
            return builder.getRelJugadorDestacamentoHandler().getRelJugadorDestacamento(id);
        }

        public void createRelJugadorDestacamento(RelJugadorDestacamento reljugadordestacamento)
        {
            builder.getRelJugadorDestacamentoHandler().createRelJugadorDestacamento(reljugadordestacamento);
        }

        public void updateRelJugadorDestacamento(RelJugadorDestacamento reljugadoredificio)
        {
            builder.getRelJugadorDestacamentoHandler().updateRelJugadorDestacamento(reljugadoredificio);
        }

        public void deleteRelJugadorDestacamento(int id)
        {
            builder.getRelJugadorDestacamentoHandler().deleteRelJugadorDestacamento(id);
        }

        public List<RelJugadorDestacamento> getDestacamentosByColonia(int id)
        {
            return builder.getRelJugadorDestacamentoHandler().getDestacamentosByColonia(id);
        }
    }
}
