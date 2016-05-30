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
        public virtual Producto padre { get; set; }
        public virtual Producto hijo { get; set; }
        public int nivel { get; set; }

        public Dependencia() { }

        public Dependencia(Producto padre, Producto hijo, int nivel)
        {
            this.padre = padre;
            this.hijo = hijo;
            this.nivel = nivel;
        }
    }
}
