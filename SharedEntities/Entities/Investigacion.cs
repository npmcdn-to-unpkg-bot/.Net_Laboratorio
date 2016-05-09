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
        public Dictionary<String, float> costo;
        public Dictionary<String, float> factorNivel;
        public int nivel;
    }
}
