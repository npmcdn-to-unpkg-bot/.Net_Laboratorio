using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class MapaNode
    {
        public string nombre;
        public int nivel;
        public int cantidad;

        public MapaNode(string name, int nivel, int cantidad)
        {
            this.nombre = name;
            this.nivel = nivel;
            this.cantidad = cantidad;
        }
    }
}
