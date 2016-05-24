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
        public int idUnidadDependiente { get; set; }
        public int idInvestigacionDependiente { get; set; }
        public int idUniQueDepende { get; set; }
        public int idInvQueDepende { get; set; }
        public int level { get; set; }
    }
}
