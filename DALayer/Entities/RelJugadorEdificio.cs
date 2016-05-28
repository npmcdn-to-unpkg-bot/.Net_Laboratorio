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
        public RelJugadorMapa colonia { get; set; }
        public Edificio edificio { get; set; }
        public int nivelE { get; set; }

        public RelJugadorEdificio() { }

        public RelJugadorEdificio(SharedEntities.Entities.RelJugadorMapa c, SharedEntities.Entities.Edificio e, int nivelE)
        {
            var col = new RelJugadorMapa(c.nivel1, c.nivel2, c.nivel3, c.nivel4, c.nivel5, c.jugador);
            col.id = c.id;
            var ed = new Edificio(e.nombre, e.descripcion, e.foto, e.costo, e.capacidad, e.ataque, e.escudo, e.efectividadAtaque, e.vida);
            ed.id = e.id;

            this.colonia = col;
            this.edificio = ed;
            this.nivelE = nivelE;
        }
    }
}
