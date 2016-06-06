using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface ICostoHandler
    {
        void createCosto(Costo cost);
        void deleteCosto(int id);
        void updateCosto(Costo cost);
        Costo getCosto(int id);
    }
}
