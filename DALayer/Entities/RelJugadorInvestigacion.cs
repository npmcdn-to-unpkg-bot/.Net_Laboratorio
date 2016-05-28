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
    public class RelJugadorInvestigacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public RelJugadorMapa colonia { get; set; }
        public Investigacion investigacion { get; set; }
        public int nivel { get; set; }

        public RelJugadorInvestigacion() { }

        public RelJugadorInvestigacion(SharedEntities.Entities.RelJugadorMapa c, SharedEntities.Entities.Investigacion i, int nivel)
        {
            var col = new RelJugadorMapa(c.nivel1, c.nivel2, c.nivel3, c.nivel4, c.nivel5, c.jugador);
            col.id = c.id;
            var inv = new Investigacion(i.nombre, i.descripcion, i.foto, i.costo, i.factorCostoNivel);
            inv.id = i.id;

            this.colonia = col;
            this.investigacion = inv;
            this.nivel = nivel;
        }
    }
}
