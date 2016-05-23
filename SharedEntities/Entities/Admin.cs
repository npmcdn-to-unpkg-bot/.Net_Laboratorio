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

        public Admin(int id, String name, String apellidos, String email, String usuario, String password,
            byte[] foto, int telefono)
        {
            this.id = id;
            this.name = name;
            this.apellidos = apellidos;
            this.email = email;
            this.usuario = usuario;
            this.password = password;
            this.foto = foto;
            this.telefono = telefono;
        }
    }
}
