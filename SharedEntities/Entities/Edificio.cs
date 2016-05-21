using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Edificio: Unidad
    {
        public int nivel;
        public float factorCostoNivel;
        public float factorCapacidad;

        public Edificio(Guid id, string description, byte[] photo, float capacidadI, float ataque, float escudo,
            float efectividadAtaque, float vida, int nivel, float factorCN, float factorC)
        {
            this.id = id;
            this.descripcion = description;
            this.foto = photo;
            this.capacidadInicial = capacidadI;
            this.ataque = ataque;
            this.escudo = escudo;
            this.efectividadAtaque = efectividadAtaque;
            this.vida = vida;
            this.nivel = nivel;
            this.factorCostoNivel = factorCN;
            this.factorCapacidad = factorC;
        }
    }
}
