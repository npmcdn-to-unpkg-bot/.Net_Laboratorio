using System;
using System.ComponentModel.DataAnnotations;

namespace DALayer.Entities
{
    public class Recurso {
        [Key]
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public byte[] foto { get; set; }
    }
}
