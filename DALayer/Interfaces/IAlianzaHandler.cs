using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    interface IAlianzaHandler
    {
        void createAlianza(Alianza alli);
        void deleteAlianza(string name);
        void updateAlianza(Alianza alli);
        List<Alianza> getAllAlianzas();
    }
}
