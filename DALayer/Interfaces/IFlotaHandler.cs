using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IFlotaHandler
    {
        void CreateFlota(Flota fleet);
        void DeleteFlota(Guid id);
        void UpdateFlota(Flota fleet);
        List<Flota> GetAllFlotas();
    }
}
