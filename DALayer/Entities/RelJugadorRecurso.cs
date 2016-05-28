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
    public class RelJugadorRecurso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public Recurso recurso { get; set; }
        public RelJugadorMapa colonia { get; set; }
        public int capacidad { get; set; }
        public int cantidadR { get; set; }
        public float factorIncremento { get; set; }

        public RelJugadorRecurso() { }

        public RelJugadorRecurso(SharedEntities.Entities.Recurso r, SharedEntities.Entities.RelJugadorMapa c, int capacidad, int cantidadR, float factorIncremento)
        {
            var rec = new Entities.Recurso(r.nombre, r.descripcion, r.foto);
            rec.id = r.id;
            var col = new Entities.RelJugadorMapa(c.nivel1, c.nivel2, c.nivel3, c.nivel4, c.nivel5, c.jugador);
            col.id = c.id;

            this.recurso = rec;
            this.colonia = col;
            this.capacidad = capacidad;
            this.cantidadR = cantidadR;
            this.factorIncremento = factorIncremento;
        }
    }

}
