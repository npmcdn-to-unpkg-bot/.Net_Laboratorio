using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class MapaNode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nombre { get; set; }
        public int nivel { get; set; }
        public int cantidad { get; set; }

        public MapaNode(string nombre, int nivel, int cantidad)
        {
            this.nombre = nombre;
            this.nivel = nivel;
            this.cantidad = cantidad;
        }
    }
}
