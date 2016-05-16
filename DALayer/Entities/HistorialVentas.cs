using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class HistorialVentas
    {
        public Guid id { get; set; }
        public int idusuario { get; set; }
        public string nombreOferta { get; set; }
        public DateTime fechaCompra { get; set; }
    }
}
