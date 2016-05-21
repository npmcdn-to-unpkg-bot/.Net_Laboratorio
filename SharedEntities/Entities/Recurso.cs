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

        public Recurso(Guid id,string name, string description, byte[] photo)
        {
            this.id = id;
            this.nombre = name;
            this.descripcion = description;
            this.foto = photo;
        }
    }
}
