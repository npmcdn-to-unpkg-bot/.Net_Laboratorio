using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public abstract class Unidad
    {
        public Guid id;
        /*nombre recurso, factor prod por nivel*/
        public string descripcion;
        public byte[] foto;
        Dictionary<String, float> factoresProdRecursos;
        public float capacidadInicial;
        public float ataque;
        //float defensa{get; set;} creo que sobra
        public float escudo;
        public float efectividadAtaque;
        public float vida;

    }
}
