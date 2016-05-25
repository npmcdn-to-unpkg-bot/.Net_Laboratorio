using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class RelJugadorDestacamento
    {
        public int id;
        public Jugador jugador;
        public Destacamento destacamento;
        public int nivelD;

        public RelJugadorDestacamento(int ID, Jugador jug, Destacamento desta, int levelD)
        {
            this.id = ID;
            this.jugador = jug;
            this.destacamento = desta;
            this.nivelD = levelD;
        }
    }
}
