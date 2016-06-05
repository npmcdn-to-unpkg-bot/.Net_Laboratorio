using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Entities
{
    public class Costo
    {
        public int Id { get; set; }
        public Recurso recurso { get; set; }
        public int valor { get; set; }
        public float incrementoNivel { get; set; }
        public Producto producto { get; set; }

        public Costo() { }

        public Costo(int id, Recurso rec, int valor, float incrementoNivel, Producto prod)
        {
            this.Id = id;
            this.recurso = rec;
            this.valor = valor;
            this.incrementoNivel = incrementoNivel;
            this.producto = prod;
        }
    }
}