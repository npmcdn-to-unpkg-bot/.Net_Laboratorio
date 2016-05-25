using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class RelJugadorMapa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int nivel1 { get; set; }
        public int nivel2 { get; set; }
        public int nivel3 { get; set; }
        public int nivel4 { get; set; }
        public int nivel5 { get; set; }
        public Jugador jugador { get; set; }

    }
}
