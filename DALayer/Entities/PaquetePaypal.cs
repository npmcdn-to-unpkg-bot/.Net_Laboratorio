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
        public string nombreOferta { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public Boolean ofertaActiva { get; set; }
    }
}
