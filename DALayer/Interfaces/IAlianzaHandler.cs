using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IAlianzaHandler
    {
        void createAlianza(Alianza ali);
        void deleteAlianza(Alianza ali);
        void updateAlianza(Alianza ali);
        Alianza getAlianza(int id);
        List<Alianza> getAllAlianzas();
    }
}
