using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Jugador: Usuario
    {
        public string nickname;
        public int nivel;
        public float experiencia;
        private string id1;
        private string nombre;
        private string apellido;

        public string UserName { get; set; }
        public string Id { get; set; }

        public Jugador(int id, String name, String apellidos, String email, String usuario, String password,
            byte[] foto, string nickname, int nivel, float exp)
        {
            this.id = id;
            this.name = name;
            this.apellidos = apellidos;
            this.email = email;
            this.usuario = usuario;
            this.password = password;
            this.foto = foto;
            this.nickname = nickname;
            this.nivel = nivel;
            this.experiencia = exp;
        }

        public Jugador(string id1, string nombre, string apellido, string email, string userName, byte[] foto, string nickname, int nivel, float experiencia)
        {
            this.id1 = id1;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            UserName = userName;
            this.foto = foto;
            this.nickname = nickname;
            this.nivel = nivel;
            this.experiencia = experiencia;
        }
    }
}
