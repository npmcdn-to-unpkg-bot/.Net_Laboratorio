using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Investigacion : Producto
    {
        public float factorCostoNivel;

        public Investigacion(int id, string name, string description, byte[] photo, List<Costo> cost, float costLevelFactor)
        {
            this.id = id;
            this.nombre = name;
            this.descripcion = description;
            this.foto = photo;
            this.costos = cost;
            this.factorCostoNivel = costLevelFactor;
        }
    }
}
