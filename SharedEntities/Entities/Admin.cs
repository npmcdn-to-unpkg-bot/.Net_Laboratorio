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
        private string apellido;
        private string id1;
        private string nombre;
        private string userName;

        public Admin(string id1, string nombre, string apellido, string email, string userName, byte[] foto, int telefono)
        {
            this.id1 = id1;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.userName = userName;
            this.foto = foto;
            this.telefono = telefono;
        }

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

        public string Id { get; set; }
    }
}
