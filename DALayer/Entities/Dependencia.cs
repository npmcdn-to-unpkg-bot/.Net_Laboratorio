using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DALayer.Entities
{
    public class Dependencia
    {
        [Key]
        public String nombre { get; set; }
        public int level { get; set; }
        List<Dependencia> dependencias { get; set; }


    }
}
