using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Investigacion : Producto
    {
        public Investigacion() { }

        public Investigacion(string nombre, string descripcion, byte[] foto)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.foto = foto;
        }
    }
}
