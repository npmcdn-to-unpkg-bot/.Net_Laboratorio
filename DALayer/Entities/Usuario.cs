using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Entities
{
    public abstract class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id{get; set;}
        public String nombre{get; set;}
        public String apellido{get; set;}
        public String email{get; set;}
        public String usuario{get; set;}
        public String password{get; set;}
        public byte[] foto { get; set; }
    }
}
