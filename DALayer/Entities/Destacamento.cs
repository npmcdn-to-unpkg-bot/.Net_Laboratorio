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

        public Destacamento(string nombre, string descripcion, byte[] foto, float ataque, float escudo, float efectividadAtaque, float vida, float velocidad, 
                            bool enMision, int tInicial, int incrementoT)
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
            this.tiempoInicial = tInicial;
            this.incrementoTiempo = incrementoT;
        }

        public SharedEntities.Entities.Destacamento getShared()
        {
            var costosS = new List<SharedEntities.Entities.Costo>();
            foreach (var c in costos)
            {
                costosS.Add(c.getShared());
            }
            var capacidadS = new List<SharedEntities.Entities.Capacidad>();
            foreach (var cap in capacidad)
            {
                capacidadS.Add(cap.getShared());
            }
            var produceS = new List<SharedEntities.Entities.Produce>();
            foreach (var item in produce)
            {
                produceS.Add(item.getShared());
            }
            return new SharedEntities.Entities.Destacamento(id, descripcion, foto, ataque, escudo, efectividadAtaque, vida, velocidad,
                enMision, nombre, costosS, capacidadS, produceS, tiempoInicial, incrementoTiempo);
        }
    }
}
