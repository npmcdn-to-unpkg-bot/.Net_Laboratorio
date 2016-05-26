using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class RelJugadorMapa
    {
        public int id;
        public int nivel1;
        public int nivel2;
        public int nivel3;
        public int nivel4;
        public int nivel5;
        public Jugador jugador;

        public RelJugadorMapa(int ide, int niv1, int niv2, int niv3, int niv4, int niv5, Jugador jug)
        {
            this.id = ide;
            this.nivel1 = niv1;
            this.nivel2 = niv2;
            this.nivel3 = niv3;
            this.nivel4 = niv4;
            this.nivel5 = niv5;
            this.jugador = jug;
        }
    }
}
