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
            // COSTOS
            foreach (var c in rel.edificio.costos)
            {
                c.incrementoNivel = c.incrementoNivel / 100 + 1;
                for (int i = 0; i < rel.nivelE; i++)
                {
                    c.valor = Convert.ToInt32(c.valor * c.incrementoNivel);
                }
            }
            // CAPACIDAD
            foreach (var c in rel.edificio.capacidad)
            {
                if (nivelE == 0)
                {
                    c.valor = 0;
                }
                else
                {
                    c.incrementoNivel = c.incrementoNivel / 100 + 1;
                    for (int i = 1; i < rel.nivelE; i++)
                    {
                        c.valor = Convert.ToInt32(c.valor * c.incrementoNivel);
                    }
                }
            }
            // PRODUCCION
            foreach (var p in rel.edificio.produce)
            {
                if (nivelE == 0)
                {
                    p.valor = 0;
                }
                else
                {
                    p.incrementoNivel = p.incrementoNivel / 100 + 1;
                    for (int i = 1; i < rel.nivelE; i++)
                    {
                        p.valor = Convert.ToInt32(p.valor * p.incrementoNivel);
                    }
                }
            }
            // TIEMPO DE CONSTRUCCION SIGUIENTE NIVEL
            rel.edificio.incrementoTiempo = rel.edificio.incrementoTiempo / 100 + 1;
            for (int i = 0; i < nivelE; i++)
            {
                rel.edificio.tiempoInicial = Convert.ToInt32(rel.edificio.tiempoInicial * rel.edificio.incrementoTiempo);
            }
            return rel;
        }
    }
}
