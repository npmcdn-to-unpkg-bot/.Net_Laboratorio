using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IDependenciaHandler
    {
        void createDependencia(Dependencia dep);
        void deleteDependencia(int id);
        void updateDependencia(Dependencia dep);
        Dependencia getDependencia(int id);
        List<Dependencia> getAllDependencias();
        List<Dependencia> getDependenciasByProdId(int id);
        List<Producto> getAllProductos();
    }
}
