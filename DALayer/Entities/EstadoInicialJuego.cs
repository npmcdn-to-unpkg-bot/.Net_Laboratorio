using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Guid id { get; set; }
        public Dictionary<String, float> estadoInicial { get; set; }
    }
}
