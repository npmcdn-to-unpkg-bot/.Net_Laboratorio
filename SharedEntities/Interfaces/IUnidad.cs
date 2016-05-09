using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Interfaces
{
    public interface IUnidad
    {
        String getName();
        float eficienciaAtaque();
        float escudo();
        float vida();
    }
}
