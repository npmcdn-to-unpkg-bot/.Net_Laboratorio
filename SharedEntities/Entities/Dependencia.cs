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
        public int id;
        public String nombre;
        public int level;
        public List<Dependencia> dependencias;

        public Dependencia(int id, string name, int nivel, List<Dependencia> depend)
        {
            this.id = id;
            this.nombre = name;
            this.level = nivel;
            this.dependencias = depend;
        }

    }
}
