using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Entities
{
    public class Recurso {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int cantInicial { get; set; }
        public byte[] foto { get; set; }

        public Recurso() { }

        public Recurso(string nombre, string descripcion, int cantInicial, byte[] foto)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.cantInicial = cantInicial;
            this.foto = foto;
        }
    }
}
