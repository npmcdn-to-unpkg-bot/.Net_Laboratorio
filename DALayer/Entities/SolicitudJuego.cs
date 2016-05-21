using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Entities
{
    public class SolicitudJuego
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {get; set;}
        public String email { get; set; }
        public String user { get; set; }
        public String password { get; set; }
        public String token { get; set; }
        public DateTime expirationTime { get; set; }

    }
}
