using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    /**
    administrador del juego
    **/
    public class Admin: Usuario
    {
        public int telefono;

        public Admin(string id1, string nombre, string apellido, string email, string userName, byte[] foto, int telefono)
        {
            this.id = id1;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.usuario = userName;
            this.foto = foto;
            this.telefono = telefono;
        }
    }
}
