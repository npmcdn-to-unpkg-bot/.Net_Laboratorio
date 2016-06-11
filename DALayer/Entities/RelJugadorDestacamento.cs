using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class RelJugadorDestacamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public virtual RelJugadorMapa colonia { get; set; }
        public virtual Destacamento destacamento { get; set; }
        public int cantidad { get; set; } 

        public RelJugadorDestacamento() { }

        public RelJugadorDestacamento(RelJugadorMapa col, Destacamento des, int cant)
        {
            this.colonia = col;
            this.destacamento = des;
            this.cantidad = cant;
        }

        public SharedEntities.Entities.RelJugadorDestacamento getShared()
        {
            return new SharedEntities.Entities.RelJugadorDestacamento(id, colonia.getShared(), destacamento.getShared(), cantidad);
        }
    }
}
