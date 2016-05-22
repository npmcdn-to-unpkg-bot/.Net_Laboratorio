using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class MapaNode
    {
        public int id;
        public string nombre;
        public int nivel;
        public int cantidad;

        public MapaNode(int id, string name, int nivel, int cantidad)
        {
            this.id = id;
            this.nombre = name;
            this.nivel = nivel;
            this.cantidad = cantidad;
        }
    }
}
