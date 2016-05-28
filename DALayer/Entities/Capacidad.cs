using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DALayer.Entities
{
    public class Capacidad
    {
        public int Id { get; set; }
        public string idRecurso { get; set; }
        public int valor { get; set; }
        public float incrementoNivel { get; set; }

        public Capacidad() { }

        public Capacidad(string idRecurso, int valor, float incrementoNivel)
        {
            this.idRecurso = idRecurso;
            this.valor = valor;
            this.incrementoNivel = incrementoNivel;
        }
    }
}