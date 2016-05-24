using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class RelJugadorEdificio
    {
        public int id;
        public Jugador jugador;
        public Edificio edificio;
        public int nivelE;

        public RelJugadorEdificio(int ID, Jugador jug, Edificio edi, int levelB)
        {
            this.id = ID;
            this.jugador = jug;
            this.edificio = edi;
            this.nivelE = levelB;
        }
    }
}
