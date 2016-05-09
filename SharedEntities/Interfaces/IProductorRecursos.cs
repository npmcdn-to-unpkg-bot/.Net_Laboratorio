using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Interfaces
{
    public interface IProductorRecursos
    {
        /* tiempo debe ser la diferencia en milisegundos entre 2 DateTime*/
        IRecursoInfo produccionRecurso(String nombreRecurso, float tiempo);
    }
}
