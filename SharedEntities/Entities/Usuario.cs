using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public abstract class Usuario
    {
        public String nombre;
        public String apellido;
        public String email;
        public String usuario;
        public String password;
        public byte[] foto;
        public string id;
        public DateTime CreatedDate { get; set; }
    }
}
