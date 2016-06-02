using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Interfaces
{
    public interface IRelJugadorMapaHandler
    {
        void createRelJugadorMapa(RelJugadorMapa r);
        void deleteRelJugadorMapa(int id);
        void updateRelJugadorMapa(RelJugadorMapa r);
        RelJugadorMapa getRelJugadorMapa(int id);
        List<RelJugadorMapa> getMapasByJugador(string id);
        List<RelJugadorMapa> getColoniasByCoord(int n1, int n2, int n3, int n4);
        List<RelJugadorMapa> getColoniasPorVista(int[] coordenadas);
    }
}
