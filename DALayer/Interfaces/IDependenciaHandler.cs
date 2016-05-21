using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    interface IDependenciaHandler
    {
        void createDependencia(Dependencia dep);
        void deleteDependencia(string nombre);
        void updateDependencia(Dependencia dep);
        List<Dependencia> getAllDependencias();
    }
}
