using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Produce
    {
        public int Id;
        public Recurso recurso;
        public int idProducto;
        public int valor;
        public float incrementoNivel;

        public Produce(int id, Recurso rec, int idProducto, int valor, float inc)
        {
            this.Id = id;
            this.recurso = rec;
            this.idProducto = idProducto;
            this.valor = valor;
            this.incrementoNivel = inc;
        }
    }
}
