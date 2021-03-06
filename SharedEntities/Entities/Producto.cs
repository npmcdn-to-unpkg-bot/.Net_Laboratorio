﻿using System.Collections.Generic;

namespace SharedEntities.Entities
{
    public abstract class Producto
    {
        public int id;
        public string nombre;
        public string descripcion;
        public string foto;
        public List<Costo> costos;
        public List<Capacidad> capacidad;
        public int tiempoInicial;
        public float incrementoTiempo;
        public List<Produce> produce;

        public void addCosto(Costo c)
        {
            if (this.costos == null)
            {
                this.costos = new List<Costo>();
            }
            this.costos.Add(c);
        }

        public void setCosto(List<Costo> c)
        {
            this.costos = c;
        }

        public List<Costo> getCosto()
        {
            return this.costos;
        }
    }
}