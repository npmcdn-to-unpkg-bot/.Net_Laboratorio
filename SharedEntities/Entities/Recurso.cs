namespace SharedEntities.Entities
{
    public class Recurso {
        public int id;
        public string nombre;
        public string descripcion;
        public int cantInicial;
        public int capacidadInicial;
        public int produccionXTiempo;
        public byte[] foto; 

        public Recurso(int id, string nombre, string description, int cantInicial, int capacidadInicial, int produccionXTiempo, byte[] foto)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = description;
            this.cantInicial = cantInicial;
            this.capacidadInicial = capacidadInicial;
            this.produccionXTiempo = produccionXTiempo;
            this.foto = foto;
        }
    }
}
