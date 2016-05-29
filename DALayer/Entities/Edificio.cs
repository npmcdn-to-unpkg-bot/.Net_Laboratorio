using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Entities
{
    public class Edificio : Unidad
    {
        public Edificio() { }

        public Edificio(string nombre, string descripcion, byte[] foto,/* List<Costo> costos, List<Capacidad> capacidad,*/ float ataque, float escudo, float efectividadAtaque, float vida)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.foto = foto;
            //this.costos = costos;
            //this.capacidad = capacidad;
            this.ataque = ataque;
            this.escudo = escudo;
            this.efectividadAtaque = efectividadAtaque;
            this.vida = vida;
        }
    }
}
