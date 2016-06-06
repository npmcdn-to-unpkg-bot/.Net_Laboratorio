using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Destacamento: Unidad
    {
        public float velocidad { get; set; }
        public Boolean enMision { get; set; }

        public Destacamento() { }

        public Destacamento(string nombre, string descripcion, byte[] foto, float ataque, float escudo, float efectividadAtaque, float vida, float velocidad, bool enMision)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.foto = foto;
            this.ataque = ataque;
            this.escudo = escudo;
            this.efectividadAtaque = efectividadAtaque;
            this.vida = vida;
            this.velocidad = velocidad;
            this.enMision = enMision;
        }
    }
}
