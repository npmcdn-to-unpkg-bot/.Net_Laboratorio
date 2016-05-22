using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class PaquetePaypal
    {
        public int id;
        public string nombreOferta;
        public string producto;
        public int cantidad;
        public int precio;
        public bool ofertaActiva;

        public PaquetePaypal(int id, string nameO, string product, int cant, int price, bool active)
        {
            this.id = id;
            this.nombreOferta = nameO;
            this.producto = product;
            this.cantidad = cant;
            this.precio = price;
            this.ofertaActiva = active;
        }
    }
}
