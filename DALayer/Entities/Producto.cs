using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Entities
{
    public abstract class Producto //Es todo lo que se puede construir, Edificio, Destacamento e Investigacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public byte[] foto { get; set; }
        public List<Costo> costos { get; set; }
        public List<Capacidad> capacidad { get; set; }

        public void addCosto(Costo c)
        {
            if (this.costos == null)
            {
                this.costos = new List<Costo>();
            }
            this.costos.Add(c);
        }

        public void setCosto(List<Costo> c)
        {
            this.costos = c;
        }

        public List<Costo> getCosto()
        {
            return this.costos;
        }
    }
}