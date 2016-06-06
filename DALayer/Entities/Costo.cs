using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Entities
{
    public class Costo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Recurso recurso { get; set; }
        public Producto producto { get; set; }
        public int valor { get; set; }
        public float incrementoNivel { get; set; }

        public Costo() { }

        public Costo(Recurso rec, Producto prod, int valor, float incrementoNivel)
        {
            this.recurso = rec;
            this.producto = prod;
            this.valor = valor;
            this.incrementoNivel = incrementoNivel;
        }
    }
}