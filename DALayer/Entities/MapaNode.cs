using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class MapaNode
    {
        [Key]
        public string nombre { get; set; }
        public int nivel { get; set; }
        public int cantidad { get; set; }
    }
}
