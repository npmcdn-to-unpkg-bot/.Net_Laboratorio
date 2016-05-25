using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class RelJugadorRecurso
    {
        public int id;
        public Jugador jugador;
        public Recurso recurso;
        public int cantidadR;

        public RelJugadorRecurso(int ID, Jugador jug, Recurso rec, int cantR)
        {
            this.id = ID; 
            this.jugador = jug;
            this.recurso = rec;
            this.cantidadR = cantR;
        }
    }
}
