using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Edificio: Unidad
    {
        public Edificio(int id, string descripcion, string foto, float ataque, float escudo, float efectividadAtaque, float vida,
                        string nombre, List<Costo> costos, List<Capacidad> capacidad, List<Produce> produce, int tInicial, float incrementoT)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.foto = foto;
            this.ataque = ataque;
            this.escudo = escudo;
            this.efectividadAtaque = efectividadAtaque;
            this.vida = vida;
            this.nombre = nombre;
            this.costos = costos;
            this.capacidad = capacidad;
            this.produce = produce;
            this.tiempoInicial = tInicial;
            this.incrementoTiempo = incrementoT;
        }
    }
}
