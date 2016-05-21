using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class SolicitudJuego
    {
        public int id;
        public String email;
        public String user;
        public String password;
        public String token;
        public DateTime expirationTime;

        public SolicitudJuego(int ide, string mail, string usu, string contraseña, string tok, DateTime fechaExpiracion)
        {
            this.id = ide;
            this.email = mail;
            this.user = usu;
            this.password = contraseña;
            this.token = tok;
            this.expirationTime = fechaExpiracion;
        }
    }
}
