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
        public Producto padre;
        public Producto hijo;
        public int level;

        public Dependencia(int id, Producto padre, Producto hijo, int level)
        {
            this.id = id;
            this.padre = padre;
            this.hijo = hijo;
            this.level = level;
        }

    }
}
