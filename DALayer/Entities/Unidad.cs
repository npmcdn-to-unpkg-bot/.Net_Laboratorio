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
    public abstract class Unidad : Producto
    {
        List<Costo> costo { get; set; }
        List<Capacidad> capacidad { get; set; }
        public float ataque {get; set;}
        public float escudo {get; set;}
        public float efectividadAtaque {get; set;}
        public float vida {get; set;}
        
    }
}
