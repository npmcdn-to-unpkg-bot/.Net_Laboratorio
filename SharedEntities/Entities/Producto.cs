using System.Collections.Generic;

namespace SharedEntities.Entities
{
    public abstract class Producto
    {
        public int id;
        public string nombre;
        public string descripcion;
        public byte[] foto;
        public List<Costo> costo;

        public void addCosto(Costo c)
        {
            if (this.costo == null)
            {
                this.costo = new List<Costo>();
            }
            this.costo.Add(c);
        }

        public void setCosto(List<Costo> c)
        {
            this.costo = c;
        }

        public List<Costo> getCosto()
        {
            return this.costo;
        }
    }
}