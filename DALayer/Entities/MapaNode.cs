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
        public int distance { get; set; }

        public MapaNode() { }

        public MapaNode(string nombre, int nivel, int cantidad, int distance)
        {
            this.nombre = nombre;
            this.nivel = nivel;
            this.cantidad = cantidad;
            this.distance = distance;
        }

        public SharedEntities.Entities.MapaNode getShared()
        {
            return new SharedEntities.Entities.MapaNode(id, nombre, nivel, cantidad, distance);
        }
    }
}
