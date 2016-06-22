using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IRelJugadorDestacamentoHandler
    {
        void createRelJugadorDestacamento(RelJugadorDestacamento destacamento);
        void updateRelJugadorDestacamento(RelJugadorDestacamento destacamento);
        void executeUpdateRelJD(RelJugadorDestacamento rel);
        RelJugadorDestacamento getRelJugadorDestacamento(int id);
        List<RelJugadorDestacamento> getDestacamentosByColonia(int id);
        void bajarCantidadDestacamento(int id, int baja);
        void subirCantidadDestacamento(int id, int sube);
    }
}

