using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALayer.Entities
{
    public class Alianza
    {
        public List<Jugador> miembros{get; set;}
        public List<Jugador> admins{get; set;}
        [Key]
        public String nombre{get; set;}
        public String descripcion{get; set;}
        public byte[] foto{get; set;}
    }
}
