using SharedEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Recurso {
        public int id;
        public string nombre;
        public string descripcion;
        public int cantInicial;
        public byte[] foto; 

        public Recurso(int id, string nombre, string description, int cantInicial, byte[] foto)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = description;
            this.cantInicial = cantInicial;
            this.foto = foto;
        }
    }
}
