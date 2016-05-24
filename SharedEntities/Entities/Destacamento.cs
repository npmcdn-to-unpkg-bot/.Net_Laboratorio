using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Destacamento: Unidad
    {
        public float velocidad;
        public Boolean enMision;

        public Destacamento(int id, string description, byte[] photo, float ataque, float escudo,
            float efectividadAtaque, float vida, float velocidad, Boolean enMission, string name)
        {
            this.id = id;
            this.descripcion = description;
            this.foto = photo; 
            this.ataque = ataque;
            this.escudo = escudo;
            this.efectividadAtaque = efectividadAtaque;
            this.vida = vida;
            this.velocidad = velocidad;
            this.enMision = enMission;
            this.nombre = name;
        }

        public Destacamento(int id, string descripcion, byte[] foto, float ataque, float escudo, float efectividadAtaque, float vida, float velocidad, string nombre)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.foto = foto;
            this.ataque = ataque;
            this.escudo = escudo;
            this.efectividadAtaque = efectividadAtaque;
            this.vida = vida;
            this.velocidad = velocidad;
            this.nombre = nombre;
        }
    }
}
