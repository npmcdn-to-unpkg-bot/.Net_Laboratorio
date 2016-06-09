using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Alianza
    {
        public int id;
        public String nombre;
        public String descripcion;
        public byte[] foto;
        public Jugador administrador;

        public Alianza(int id, string nombre, string descripcion, byte[] foto, Jugador administrador)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.foto = foto;
            this.administrador= administrador;
        }

        public Alianza() { }
    }
}
