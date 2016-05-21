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
        void deleteHistorialVentas(Guid ident);
        List<HistorialVentas> getAllHistorialesVenta();
        void updateHistorialVentas(HistorialVentas hv);
    }
}
