using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Edificio: Unidad
    {
        int nivel { get; set; }
        float factorCostoNivel { get; set; }
        float factorCapacidad { get; set; }
    }
}
