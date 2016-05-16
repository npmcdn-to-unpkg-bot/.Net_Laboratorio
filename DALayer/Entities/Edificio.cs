using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Edificio: Unidad
    {
        public int nivel { get; set; }
        public float factorCostoNivel { get; set; }
        public float factorCapacidad { get; set; }
    }
}
