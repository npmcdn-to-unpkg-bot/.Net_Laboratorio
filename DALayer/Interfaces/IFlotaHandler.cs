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
        void DeleteFlota(int id);
        void UpdateFlota(Flota fleet);
        Flota getFlota(int id);
        List<Flota> GetAllFlotas();
    }
}
