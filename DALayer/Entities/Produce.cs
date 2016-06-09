using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Entities
{
    public class Produce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Recurso recurso { get; set; }
        public virtual Producto producto { get; set; }
        public int valor { get; set; }
        public float incrementoNivel { get; set; }

        public Produce() { }

        public Produce(Recurso rec, Producto producto, int valor, float incrementoNivel)
        {
            this.recurso = rec;
            this.producto = producto;
            this.valor = valor;
            this.incrementoNivel = incrementoNivel;
        }

        public SharedEntities.Entities.Produce getShared()
        {
            return new SharedEntities.Entities.Produce(Id, recurso.getShared(), producto.id, valor, incrementoNivel);
        }
    }
}