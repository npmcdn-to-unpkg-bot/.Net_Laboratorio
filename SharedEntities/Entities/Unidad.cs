using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public abstract class Unidad
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public byte[] foto { get; set; }
        public List<Costo> costo { get; set; }
        public List<Capacidad> capacidad { get; set; }
        public float ataque { get; set; }
        public float escudo { get; set; }
        public float efectividadAtaque { get; set; }
        public float vida { get; set; }

        public void addCosto(Costo c)
        {
            if (this.costo == null) {
                this.costo = new List<Costo>();
            }
            this.costo.Add(c);
        }
        public void addCapacidad(Capacidad c)
        {
            if (this.capacidad == null)
            {
                this.capacidad = new List<Capacidad>();
            }
            this.capacidad.Add(c);
        }
        public void setCosto(List<Costo> c)
        {
            this.costo = c;
        }
        public void setCapacidad(List<Capacidad> c)
        {
            this.capacidad = c;
        }
    }
}
