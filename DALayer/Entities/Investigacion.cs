﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Investigacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public String nombre{get; set;}
        public string descripcion { get; set; }
        public byte[] foto { get; set; }
        public Dictionary<String, float> costo{get; set;}
        public Dictionary<String, float> factorCostoNivel{get; set;}
        public int nivel{get; set;}
    }
}
