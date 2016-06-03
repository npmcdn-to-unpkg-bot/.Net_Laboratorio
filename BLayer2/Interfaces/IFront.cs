using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Interfaces
{
    public interface IFront
    {
        // RELJUGADOREDIFICIO
        void createRelJugadorEdificio(RelJugadorEdificio relacion);
        void bajarNivel(int id);
        void subirNivel(int id);
        RelJugadorEdificio getRelJugadorEdificio(int id);
        List<RelJugadorEdificio> getEdificiosByColonia(int id);

        //RELJUGADORINVESTIGACION
        void createRelJugadorInvestigacion(RelJugadorInvestigacion relacion);
        void deleteRelJugadorInvestigacion(int id);
        void updateRelJugadorInvestigacion(RelJugadorInvestigacion relacion);
        void bajarNivelI(int id);
        void subirNivelI(int id);
        RelJugadorInvestigacion getRelJugadorInvestigacion(int id);
        List<RelJugadorInvestigacion> getInvestigacionesByColonia(int id);

        //RELJUGADORMAPA
        void createRelJugadorMapa(RelJugadorMapa r);
        void deleteRelJugadorMapa(int id);
        void updateRelJugadorMapa(RelJugadorMapa r);
        RelJugadorMapa getRelJugadorMapa(int id);
        List<RelJugadorMapa> getMapasByJugador(string id);
        List<RelJugadorMapa> getColoniasPorVista(int[] coordenadas);

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
        void bajarCantidadD(int id);
        void subirCantidadD(int id);
    }
}
