using SharedEntities.Entities;
using System.Collections.Generic;

namespace SharedEntities.Interfaces
{
    public interface IEntidadInteraccion
    {
        List<IRecursoInfo> recursos { get; }
        List<IUnidad> unidades { get; set; }
        List<IUnidad> edificios { get; set; }
        IUnidadMapa colonia { get; }
        int level { get; }
        float experience { get; set; }
        
    }
}