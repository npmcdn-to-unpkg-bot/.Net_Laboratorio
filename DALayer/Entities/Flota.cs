using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Flota
    {
        public Guid id { get; set; }
        public String typoNave { get; set; }
        public int cantidad { get; set; }
    }
}
