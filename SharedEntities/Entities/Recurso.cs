using SharedEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Recurso {
        public Guid id;
        public string nombre;
        public string descripcion;
        public byte[] foto; 

        public Recurso(Guid id, string nombre, string description, byte[] foto)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = description;
            this.foto = foto;
        }
    }
}
