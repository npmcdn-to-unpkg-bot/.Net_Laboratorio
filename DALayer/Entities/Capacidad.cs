using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DALayer.Entities
{
    public class Capacidad
    {
        public int Id { get; set; }
        public Recurso recurso { get; set; }
        public int valor { get; set; }
        public float incrementoNivel { get; set; }
        public Unidad unidad { get; set; }

        public Capacidad() { }

        public Capacidad(int id ,Recurso rec, int valor, float incrementoNivel, Unidad uni)
        {
            this.Id = id;
            this.recurso = rec;
            this.valor = valor;
            this.incrementoNivel = incrementoNivel;
            this.unidad = uni;
        }
    }
}