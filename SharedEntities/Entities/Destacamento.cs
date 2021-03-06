﻿using System;
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

        public Destacamento(int id, string description, string foto, float ataque, float escudo, float efectividadAtaque, float vida, float velocidad, 
                            Boolean enMission, string name, List<Costo> costos, List<Capacidad> capacidad, List<Produce> produce, int tInicial, float incrementoT)
        {
            this.id = id;
            this.descripcion = description;
            this.foto = foto; 
            this.ataque = ataque;
            this.escudo = escudo;
            this.efectividadAtaque = efectividadAtaque;
            this.vida = vida;
            this.velocidad = velocidad;
            this.enMision = enMission;
            this.nombre = name;
            this.costos = costos;
            this.capacidad = capacidad;
            this.tiempoInicial = tInicial;
            this.incrementoTiempo = incrementoT;
            this.produce = produce;
        }

        public Destacamento()
        {
        }
    }
}
