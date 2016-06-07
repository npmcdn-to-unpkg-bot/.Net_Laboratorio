using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IInvestigacionHandler
    {
        int createInvestigacion(Investigacion inv);
        void deleteInvestigacion(int id);
        void updateInvestigacion(Investigacion inv);
        Investigacion getInvestigacion(int id);
        List<Investigacion> getAllInvestigaciones();
    }
}
