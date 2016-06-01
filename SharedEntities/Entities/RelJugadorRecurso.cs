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
        public Recurso recurso;
        public RelJugadorMapa colonia;
        public int capacidad;
        public int cantidadR;
        public float produccionXTiempo;
        public DateTime ultimaConsulta;

        public RelJugadorRecurso(int ID, Recurso rec, RelJugadorMapa col, int cap, int cantR, float produccionXTiempo, DateTime ultimaConsulta)
        {
            this.id = ID;
            this.recurso = rec;
            this.colonia = col;
            this.capacidad = cap;
            this.cantidadR = cantR;
            this.produccionXTiempo = produccionXTiempo;
            this.ultimaConsulta = ultimaConsulta;
        }
    }
}
