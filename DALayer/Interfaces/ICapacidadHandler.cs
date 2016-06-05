using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface ICapacidadHandler
    {
        void createCapacidad(Capacidad capacidad);
        void deleteCapacidad(int id);
        void updateCapacidad(Capacidad capacidad);
        Capacidad getCapacidad(int id);
        List<Capacidad> getAllCapacidades();
    }
}
