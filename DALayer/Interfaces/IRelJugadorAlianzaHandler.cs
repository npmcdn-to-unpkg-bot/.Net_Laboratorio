using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IRelJugadorAlianzaHandler
    {
        void createRelJugadorAlianza(RelJugadorAlianza r);
        void deleteRelJugadorAlianza(int id);
        void updateRelJugadorAlianza(RelJugadorAlianza r);
        RelJugadorAlianza getRelJugadorAlianza(int id);
        List<RelJugadorAlianza> getAllRelJugadorAlianza();
        List<RelJugadorAlianza> getMiembrosByAlianza(int alianzaId);
    }
}
