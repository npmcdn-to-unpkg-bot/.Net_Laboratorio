using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Investigacion : Producto
    {
        public Dictionary<String, float> costo;
        public Dictionary<String, float> factorCostoNivel;
        public int nivel;

        public Investigacion(int id, string name, string description, byte[] photo, Dictionary<String, float> cost, Dictionary<String, float> costLevelFactor, int level )
        {
            this.id = id;
            this.nombre = name;
            this.descripcion = description;
            this.foto = photo;
            this.costo = cost;
            this.factorCostoNivel = costLevelFactor;
            this.nivel = level;
        }
    }
}
