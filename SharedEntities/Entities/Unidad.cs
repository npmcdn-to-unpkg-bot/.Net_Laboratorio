using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public abstract class Unidad : Producto
    {
        public List<Capacidad> capacidad { get; set; }
        public float ataque { get; set; }
        public float escudo { get; set; }
        public float efectividadAtaque { get; set; }
        public float vida { get; set; }

        
        public void addCapacidad(Capacidad c)
        {
            if (this.capacidad == null)
            {
                this.capacidad = new List<Capacidad>();
            }
            this.capacidad.Add(c);
        }
        
        public void setCapacidad(List<Capacidad> c)
        {
            this.capacidad = c;
        }
    }
}
