using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IConfiguracionHandler
    {
        void createConf(Configuracion conf);
        void deleteConf(int id);
        void updateConf(Configuracion conf);
        Configuracion getConfiguracion(int id);
    }
}
