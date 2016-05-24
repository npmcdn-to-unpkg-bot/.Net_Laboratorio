using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DALayer.Entities;
namespace DALayer.Entities
{
    public abstract class Unidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public byte[] foto { get; set; }
        List<Costo> costo { get; set; }
        List<Capacidad> capacidad { get; set; }
        public float ataque {get; set;}
        public float escudo {get; set;}
        public float efectividadAtaque {get; set;}
        public float vida {get; set;}
        
    }
}
