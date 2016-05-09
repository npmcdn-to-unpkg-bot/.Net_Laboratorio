using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Interfaces
{
    public interface IDependencias
    {
        Boolean isCompleto();
        List<IDependencias> faltantes();
        List<IDependencias> completos();
        List<IDependencias> dependencias();

    }
}
