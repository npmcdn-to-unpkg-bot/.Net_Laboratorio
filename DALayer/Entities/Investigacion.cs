using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Investigacion : Producto
    {
        public Investigacion() { }

        public Investigacion(string nombre, string descripcion, byte[] foto, int tInicial, float incrementoT)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.foto = foto;
            this.tiempoInicial = tInicial;
            this.incrementoTiempo = incrementoT;
        }

        public SharedEntities.Entities.Investigacion getShared()
        {
            var costosS = new List<SharedEntities.Entities.Costo>();
            foreach (var c in costos)
            {
                var cS = new SharedEntities.Entities.Costo(c.Id, c.recurso.getShared(), c.recurso.id, c.valor, c.incrementoNivel);
                costosS.Add(cS);
            } 
            var capacidadS = new List<SharedEntities.Entities.Capacidad>();
            foreach (var item in capacidad)
            {
                capacidadS.Add(item.getShared());
            }
            var produceS = new List<SharedEntities.Entities.Produce>();
            foreach (var item in produce)
            {
                produceS.Add(item.getShared());
            }
            var investigacion = new SharedEntities.Entities.Investigacion(id, nombre, descripcion, foto, costosS, capacidadS, produceS, tiempoInicial, incrementoTiempo);
            return investigacion;
        }
    }
}
