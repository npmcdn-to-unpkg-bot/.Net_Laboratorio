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

        public Alianza(int ide, string name, List<Jugador> ljug, Jugador adm, string desc, byte[] photo)
        {
            this.id = ide;
            this.nombre = name;
            this.miembros = ljug;
            this.admin = adm;
            this.descripcion = desc;
            this.foto = photo;
        }
    }
}
