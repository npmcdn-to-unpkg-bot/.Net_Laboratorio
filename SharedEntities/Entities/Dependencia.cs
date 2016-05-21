using SharedEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Dependencia
    {
        public String nombre;
        public int level;
        public List<Dependencia> dependencias;

        public Dependencia(string name, int nivel, List<Dependencia> depend)
        {
            this.nombre = name;
            this.level = nivel;
            this.dependencias = depend;
        }

    }
}
