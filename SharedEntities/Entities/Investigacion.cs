using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Investigacion
    {
        public String nombre;
        public String descripcion;
        public byte[] foto;
        public Dictionary<String, float> costo;
        public Dictionary<String, float> factorCostoNivel;
        public int nivel;

        public Investigacion(string name, string description, byte[] photo, Dictionary<String, float> cost, Dictionary<String, float> costLevelFactor, int level )
        {
            this.nombre = name;
            this.descripcion = description;
            this.foto = photo;
            this.costo = cost;
            this.factorCostoNivel = costLevelFactor;
            this.nivel = level;
        }
    }
}
