using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DALayer.Entities
{
    public class Costo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Recurso recurso { get; set; }
        public virtual Producto producto { get; set; }
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

        public SharedEntities.Entities.Costo getShared()
        {
            return new SharedEntities.Entities.Costo(Id, recurso.getShared(), recurso.id, valor, incrementoNivel);
        }
    }
}