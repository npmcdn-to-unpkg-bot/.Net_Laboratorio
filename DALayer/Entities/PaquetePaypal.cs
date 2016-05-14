using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class PaquetePaypal
    {
        [Key]
        string nombreOferta { get; set; }
        string producto { get; set; }
        int cantidad { get; set; }
        int precio { get; set; }
        Boolean ofertaActiva { get; set; }
    }
}
