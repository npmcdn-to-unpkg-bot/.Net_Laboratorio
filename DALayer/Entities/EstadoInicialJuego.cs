using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class EstadoInicialJuego
    {
        // Aqui guardaríamos el estado inicial de lo que puede tener un jugador, ejemplo recursos, edificios, destacamento
        // Duda de si es una entidad
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }       
        public RelJugadorMapa mapaInicial { get; set; }
        public RelJugadorRecurso recursoInicial { set; get; }
            
        public EstadoInicialJuego() { }
    }
}
