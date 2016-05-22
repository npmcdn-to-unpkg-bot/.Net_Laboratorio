using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public abstract class Usuario
    {
        public String name;
        public String apellidos;
        public String email;
        public String usuario;
        public String password;
        public byte[] foto;
        public int id;
    }
}
