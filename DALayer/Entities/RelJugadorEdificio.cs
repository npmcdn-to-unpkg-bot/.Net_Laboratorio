using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedEntities.Entities;

namespace DALayer.Entities
{
    public class RelJugadorEdificio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set;}
        public virtual RelJugadorMapa colonia { get; set; }
        public virtual Edificio edificio { get; set; }
        public int nivelE { get; set; }

        public RelJugadorEdificio() { }

        public RelJugadorEdificio(RelJugadorMapa c, Edificio e, int nivelE)
        {
            this.colonia = c;
            this.edificio = e;
            this.nivelE = nivelE;
        }
    }
}
