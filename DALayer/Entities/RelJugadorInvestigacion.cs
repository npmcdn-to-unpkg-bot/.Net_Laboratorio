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
        public virtual RelJugadorMapa colonia { get; set; }
        public virtual Investigacion investigacion { get; set; }
        public int nivel { get; set; }
        public DateTime finalizaConstruccion { get; set; }

        public RelJugadorInvestigacion() { }

        public RelJugadorInvestigacion(RelJugadorMapa c, Investigacion i, int nivel, DateTime finalizaConstruccion)
        {
            this.colonia = c;
            this.investigacion = i;
            this.nivel = nivel;
            this.finalizaConstruccion = finalizaConstruccion;
        }

        public SharedEntities.Entities.RelJugadorInvestigacion getShared()
        {
            var rel = new SharedEntities.Entities.RelJugadorInvestigacion(id, colonia.getShared(), investigacion.getShared(), nivel, finalizaConstruccion);
            foreach (var c in rel.investigacion.costos)
            {
                c.incrementoNivel = c.incrementoNivel / 100 + 1;
                for (int i = 0; i < rel.nivel; i++)
                {
                    c.valor = Convert.ToInt32(c.valor * c.incrementoNivel);
                }
            }
            return rel;
        }
    }
}
