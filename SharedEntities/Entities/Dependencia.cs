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
        public int idProdPadre;
        public int idProdHijo;
        public int level;

        public Dependencia(int id, int idPP, int idPH, int level)
        {
            this.id = id;
            this.idProdPadre = idPP;
            this.idProdHijo = idPH;
            this.level = level;
        }

    }
}
