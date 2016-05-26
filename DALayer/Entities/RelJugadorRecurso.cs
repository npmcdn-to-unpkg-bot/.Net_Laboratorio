using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Entities
{
    public class RelJugadorRecurso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public Jugador jugador { get; set; }
        public Recurso recurso { get; set; }
        public RelJugadorMapa colonia { get; set; }
        public int capacidad { get; set; }
        public int cantidadR { get; set; }
        public float factorIncremento { get; set; }
    }

}
