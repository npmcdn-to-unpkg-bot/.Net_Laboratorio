using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DALayer.Entities
{
    public class Capacidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Recurso recurso { get; set; }
        public Producto producto { get; set; }
        public int valor { get; set; }
        public float incrementoNivel { get; set; }

        public Capacidad() { }

        public Capacidad(Recurso rec, Producto producto, int valor, float incrementoNivel)
        {
            this.recurso = rec;
            this.producto = producto;
            this.valor = valor;
            this.incrementoNivel = incrementoNivel;
        }
    }
}