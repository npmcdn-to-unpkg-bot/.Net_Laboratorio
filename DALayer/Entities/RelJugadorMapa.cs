using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Entities
{
    public class RelJugadorMapa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int nivel1 { get; set; }
        public int nivel2 { get; set; }
        public int nivel3 { get; set; }
        public int nivel4 { get; set; }
        public int nivel5 { get; set; }
        public Jugador j { get; set; }

        public RelJugadorMapa(int nivel1, int nivel2, int nivel3, int nivel4, int nivel5, SharedEntities.Entities.Jugador j)
        {
            this.nivel1 = nivel1;
            this.nivel2 = nivel2;
            this.nivel3 = nivel3;
            this.nivel4 = nivel4;
            this.nivel5 = nivel5;
            this.j = new Entities.Jugador(j.nombre, j.apellido, j.foto, j.nickname, j.nivel, j.experiencia);
        }
    }
}
