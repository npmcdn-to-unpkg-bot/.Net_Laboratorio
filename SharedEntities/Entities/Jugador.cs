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
    }
}
