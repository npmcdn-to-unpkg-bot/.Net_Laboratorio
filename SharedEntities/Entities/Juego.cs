using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Juego
    {
        public String nombreJuego;
        public String dominio;
        public Guid id;
        public Boolean estado;
        public string descripcion;


        public Juego(string gameName, string dom, Guid ident, Boolean status, string description)
        {
            this.nombreJuego = gameName;
            this.dominio = dom;
            this.id = ident;
            this.estado = status;
            this.descripcion = description;
        }
    }
}
