using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Investigacion
    {
        public String nombre{get; set;}
        public String descripcion{get; set;}
        public Dictionary<String, float> costo{get; set;}
        public float factorCostoNivel{get; set;}
        public int nivel{get; set;}
    }
}
