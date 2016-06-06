using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public abstract class Unidad : Producto
    {
        public float ataque { get; set; }
        public float escudo { get; set; }
        public float efectividadAtaque { get; set; }
        public float vida { get; set; }
    }
}
