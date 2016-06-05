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
        private string userName;

        public DateTime LastLogin { get; set; }

        public Jugador(string id, String nombre, String apellido, String email, String usuario, String password,
            byte[] foto, string nickname, int nivel, float exp)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.usuario = usuario;
            this.password = password;
            this.foto = foto;
            this.nickname = nickname;
            this.nivel = nivel;
            this.experiencia = exp;
        }

        public Jugador()
        {
        }

        public Jugador(string id, string nombre, string apellido, string email, string userName, byte[] foto, string nickname, int nivel, float experiencia)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.userName = userName;
            this.foto = foto;
            this.nickname = nickname;
            this.nivel = nivel;
            this.experiencia = experiencia;
        }
    }
}
