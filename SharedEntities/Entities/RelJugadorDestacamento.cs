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
        public RelJugadorMapa colonia;
        public Destacamento destacamento;
        public int cantidad;

        public RelJugadorDestacamento(int ID, RelJugadorMapa col, Destacamento desta, int cant)
        {
            this.id = ID;
            this.colonia = col;
            this.destacamento = desta;
            this.cantidad = cant;
        }
    }
}
