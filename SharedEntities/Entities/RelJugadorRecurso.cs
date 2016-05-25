﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class RelJugadorRecurso
    {
        public int id;
        public Jugador jugador;
        public Recurso recurso;
        public RelJugadorMapa colonia;
        public int capacidad;
        public int cantidadR;
        public float factorIncremento;

        public RelJugadorRecurso(int ID, Jugador jug, Recurso rec, RelJugadorMapa col, int cap, int cantR, float facInc)
        {
            this.id = ID; 
            this.jugador = jug;
            this.recurso = rec;
            this.colonia = col;
            this.capacidad = cap;
            this.cantidadR = cantR;
            this.factorIncremento = facInc;
        }
    }
}
