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

        public Destacamento(int id, string description, byte[] photo, float capacidadI, float ataque, float escudo,
            float efectividadAtaque, float vida, float velocidad, Boolean enMission)
        {
            this.id = id;
            this.descripcion = description;
            this.foto = photo;
            this.capacidadInicial = capacidadI;
            this.ataque = ataque;
            this.escudo = escudo;
            this.efectividadAtaque = efectividadAtaque;
            this.vida = vida;
            this.velocidad = velocidad;
            this.enMision = enMission;
        }

    }
}
