using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IHistorialVentasHandler
    {
        void createHistorialVentas(HistorialVentas hv);
        void deleteHistorialVentas(int id);
        void updateHistorialVentas(HistorialVentas hv);
        HistorialVentas getHistorialVentas(int id);
        List<HistorialVentas> getAllHistorialesVenta();
        
    }
}
