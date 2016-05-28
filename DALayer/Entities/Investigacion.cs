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
        public float factorCostoNivel;

        public Investigacion() { }

        public Investigacion(string nombre, string descripcion, byte[] foto, List<SharedEntities.Entities.Costo> costosS, float factorCostoNivel)
        {
            var costos = new List<Costo>();
            foreach (var c in costosS)
            {
                var cos = new Costo(c.idRecurso, c.valor, c.incrementoNivel);
                costos.Add(cos);
            }

            this.nombre = nombre;
            this.descripcion = descripcion;
            this.foto = foto;
            this.costo = costos;
            this.factorCostoNivel = factorCostoNivel;
        }
    }
}
