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
        public DateTime finalizaConstruccion { get; set; }

        public RelJugadorEdificio() { }

        public RelJugadorEdificio(RelJugadorMapa c, Edificio e, int nivelE, DateTime finalizaConstruccion)
        {
            this.colonia = c;
            this.edificio = e;
            this.nivelE = nivelE;
            this.finalizaConstruccion = finalizaConstruccion;
        }

        public SharedEntities.Entities.RelJugadorEdificio getShared()
        {
            var rel = new SharedEntities.Entities.RelJugadorEdificio(id, colonia.getShared(), edificio.getShared(), nivelE, finalizaConstruccion);
            foreach (var c in rel.edificio.costos)
            {
                c.incrementoNivel = c.incrementoNivel / 100 + 1;
                for (int i = 0; i < rel.nivelE; i++)
                {
                    c.valor = Convert.ToInt32(c.valor * c.incrementoNivel);
                }
            }
            return rel;
        }
    }
}
