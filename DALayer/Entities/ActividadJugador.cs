using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class ActividadJugador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string UserId { get; set; }
        public string tipo { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public ActividadJugador() { }
    }
}
