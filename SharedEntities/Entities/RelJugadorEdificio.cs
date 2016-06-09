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
        public RelJugadorMapa colonia;
        public Edificio edificio;
        public int nivelE;
        public DateTime finalizaConstruccion;

        public RelJugadorEdificio(int ID, RelJugadorMapa col, Edificio edi, int levelB, DateTime finalizaConstruccion)
        {
            this.id = ID;
            this.colonia = col;
            this.edificio = edi;
            this.nivelE = levelB;
            this.finalizaConstruccion = finalizaConstruccion;
        }
    }
}
