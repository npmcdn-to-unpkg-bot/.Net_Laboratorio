using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Destacamento: Unidad
    {
        public float velocidad { get; set; }
        public Boolean enMision { get; set; }

        public Destacamento() { }
    }
}
