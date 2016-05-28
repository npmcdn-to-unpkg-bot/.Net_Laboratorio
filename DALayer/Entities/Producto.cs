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
        public List<Costo> costo { get; set; }

        public void addCosto(Costo c)
        {
            if (this.costo == null)
            {
                this.costo = new List<Costo>();
            }
            this.costo.Add(c);
        }

        public void setCosto(List<Costo> c)
        {
            this.costo = c;
        }

        public List<Costo> getCosto()
        {
            return this.costo;
        }
    }
}