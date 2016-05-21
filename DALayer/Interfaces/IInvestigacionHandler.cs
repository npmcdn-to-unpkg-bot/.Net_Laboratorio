using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    interface IInvestigacionHandler
    {
        void createInvestigacion(Investigacion inv);
        void deleteInvestigacion(string name);
        void updateInvestigacion(Investigacion inv);
        List<Investigacion> getAllInvestigaciones();
    }
}
