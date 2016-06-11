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
        public String descripcion{get; set;}
        public byte[] foto{get; set;}
        public virtual Jugador administrador { get; set; }

        public Alianza() { }

        public Alianza( string nombre, string descripcion, byte[] foto, Jugador administrador)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.foto = foto;
            this.administrador = administrador;
        }

        public SharedEntities.Entities.Alianza getShared()
        {
            var alianza = new SharedEntities.Entities.Alianza(id, nombre, descripcion, foto, administrador.getShared());
            return alianza;
        }
    }
}
