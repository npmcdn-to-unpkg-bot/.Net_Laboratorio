using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Entities
{
    public class Alianza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public String nombre { get; set; }
        public List<Jugador> miembros{get; set;}
        public Jugador admin{get; set;}
        public String descripcion{get; set;}
        public byte[] foto{get; set;}

        public Alianza() { }
    }
}
