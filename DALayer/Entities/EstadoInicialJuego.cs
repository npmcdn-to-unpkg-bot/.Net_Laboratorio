using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Entities
{
    public class EstadoInicialJuego
    {

        // Aqui guardaríamos el estado inicial de lo que puede tener un jugador, ejemplo recursos, edificios, destacamento
        // Duda de si es una entidad
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public virtual Recurso r { get; set; }
        public int cantidad { get; set; }
            
        public EstadoInicialJuego() { }

        public EstadoInicialJuego(Recurso r, int cantidad)
        {
            this.r = r;
            this.cantidad = cantidad;
        }
    }
}
