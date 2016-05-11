using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Unidad
    {
        /*nombre recurso, facor prod por nivel*/
        Dictionary<String, float> factoresProdRecursos{get; set;}
        float capacidadInicial{get; set;}
        float ataque{get; set;}
        float defensa{get; set;}
        float escudo{get; set;}
        float efectividadAtaque{get; set;}
        float vida{get; set;}

    }
}
