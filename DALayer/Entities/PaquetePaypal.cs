using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class PaquetePaypal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nombreOferta { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public int precio { get; set; }
        public bool ofertaActiva { get; set; }
    }
}
