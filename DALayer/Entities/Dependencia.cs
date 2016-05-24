using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Entities
{
    public class Dependencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public Producto padre { get; set; }
        public Producto hijo { get; set; }
        public int level { get; set; }

        public Dependencia() { }

        public Dependencia(Producto padre, Producto hijo, int nivel)
        {
            this.padre = padre;
            this.hijo = hijo;
            this.level = nivel;
        }
    }
}
