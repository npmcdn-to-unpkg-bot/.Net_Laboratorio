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
        public int idProdPadre { get; set; }
        public int idProdHijo { get; set; }
        public int level { get; set; }

        public Dependencia() { }

        public Dependencia(int idPP, int idPH, int nivel)
        {
            this.idProdPadre = idPP;
            this.idProdHijo = idPH;
            this.level = nivel;
        }
    }
}
