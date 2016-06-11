using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class RelJugadorAlianza
    {

        public int id;
        public Alianza alianza;
        public Jugador miembro;
        public bool activo;

        public RelJugadorAlianza() { }

        public RelJugadorAlianza(int id , Alianza alianza , Jugador miembro, bool activo)
        {
            this.id = id;
            this.alianza = alianza;
            this.miembro = miembro;
            this.activo = activo;
        }


    }
}
