using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Edificio: Unidad
    {
        public Edificio(int id, string descripcion, byte[] foto, float ataque, float escudo, float efectividadAtaque, float vida,/*
            int nivel, float factorCostoNivel, float factorCapacidad,*/ string nombre)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.foto = foto;
            this.ataque = ataque;
            this.escudo = escudo;
            this.efectividadAtaque = efectividadAtaque;
            this.vida = vida;
            //this.nivel = nivel;
            //this.factorCostoNivel = factorCostoNivel;
            //this.factorCapacidad = factorCapacidad;
            this.nombre = nombre;
        }
    }
}
