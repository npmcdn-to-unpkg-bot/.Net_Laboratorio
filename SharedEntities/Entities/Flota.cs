using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Flota
    {
        public int id;
        public String typoNave;
        public int cantidad;

        public Flota (int ident, string tynave, int cant)
        {
            this.id = ident;
            this.typoNave = tynave;
            this.cantidad= cant;
        }
    }
}
