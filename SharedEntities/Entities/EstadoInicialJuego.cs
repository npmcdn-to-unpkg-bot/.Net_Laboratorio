using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class EstadoInicialJuego
    {
        public int id;
        public Recurso r;
        public int cantidad;

        public EstadoInicialJuego(int id, Recurso r, int cantidad)
        {
            this.id = id;
            this.r = r;
            this.cantidad = cantidad;
        }
    }
}
