using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class HistorialVentas
    {
        Guid id { get; set; }
        int idusuario { get; set; }
        string nombreOferta { get; set; }
        DateTime fechaCompra { get; set; }
    }
}
