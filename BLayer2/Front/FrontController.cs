using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLayer.Interfaces;
using DALayer.Interfaces;
using SharedEntities.Entities;

namespace BLayer.Front
{
    public class FrontController : IFront
    {
        private IApi builder;

        public FrontController(string tId, IApi gc)
        {
            builder = gc;
            tId = tId.Replace(" ", "_");
            builder.setTenant(tId);
        }

        //TENANT
        public bool existGame(string gameName)
        {
            return builder.getTenantHandler().tenantExist(gameName);
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

        public void subirNivel(int id)
        {
            builder.getRelJugadorEdificioHandler().subirNivel(id);
        }

        public void bajarNivel(int id)
        {
            builder.getRelJugadorEdificioHandler().bajarNivel(id);
        }

        public List<RelJugadorEdificio> getEdificiosByColonia(int id)
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

        public void updateRelJugadorInvestigacion(RelJugadorInvestigacion reljugadorinvestigacion)
        {
            builder.getRelJugadorInvestigacionHandler().updateRelJugadorInvestigacion(reljugadorinvestigacion);
        }

        public void deleteRelJugadorInvestigacion(int id)
        {
            builder.getRelJugadorInvestigacionHandler().deleteRelJugadorInvestigacion(id);
        }

        public List<RelJugadorInvestigacion> getInvestigacionesByColonia(int id)
        {
            return builder.getRelJugadorInvestigacionHandler().getInvestigacionesByColonia(id);
        }

        public void subirNivelI(int id)
        {
            builder.getRelJugadorInvestigacionHandler().subirNivelI(id);
        }

        public void bajarNivelI(int id)
        {
            builder.getRelJugadorInvestigacionHandler().bajarNivelI(id);
        }

        //RELJUGADORMAPAS
        public RelJugadorMapa getRelJugadorMapa(int id)
        {
            return builder.getRelJugadorMapaHandler().getRelJugadorMapa(id);
        }

        public void createRelJugadorMapa(RelJugadorMapa reljugadormapa)
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

        public List<RelJugadorMapa> getMapasByJugador(string id)
        {
            return builder.getRelJugadorMapaHandler().getMapasByJugador(id);
        }

        public List<RelJugadorMapa> getColoniasPorVista(int[] coordenadas)
        {
            return builder.getRelJugadorMapaHandler().getColoniasPorVista(coordenadas);
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

        public List<RelJugadorDestacamento> getDestacamentosByColonia(int id)
        {
            return builder.getRelJugadorDestacamentoHandler().getDestacamentosByColonia(id);
        }

        public void subirCantidadDestacamento(int id, int sube)
        {
            builder.getRelJugadorDestacamentoHandler().subirCantidadDestacamento(id, sube);
        }

        public void bajarCantidadDestacamento(int id, int baja)
        {
            builder.getRelJugadorDestacamentoHandler().bajarCantidadDestacamento(id, baja);
        }
    }
}
