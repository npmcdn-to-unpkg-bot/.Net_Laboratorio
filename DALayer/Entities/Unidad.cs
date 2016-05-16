using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DALayer.Entities
{
    public class Unidad
    {
        [Key]
        public Guid id { get; set; }
        /*nombre recurso, factor prod por nivel*/
        public string descripcion { get; set; }
        public byte[] foto { get; set; }
        Dictionary<String, float> factoresProdRecursos{get; set;}
        float capacidadInicial{get; set;}
        float ataque{get; set;}
        //float defensa{get; set;} creo que sobra
        float escudo{get; set;}
        float efectividadAtaque{get; set;}
        float vida{get; set;}

    }
}
