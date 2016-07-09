using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Investigacion : Producto
    {
        public Investigacion(int id, string name, string description, string foto, List<Costo> cost, List<Capacidad> capacidad,
            List<Produce> produce, int tInicial, float incrementoT)
        {
            this.id = id;
            this.nombre = name;
            this.descripcion = description;
            this.foto = foto;
            this.costos = cost;
            this.tiempoInicial = tInicial;
            this.incrementoTiempo = incrementoT;
            this.capacidad = capacidad;
            this.produce = produce;
        }
    }
}
