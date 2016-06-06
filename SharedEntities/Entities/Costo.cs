namespace SharedEntities.Entities
{
    public class Costo
    {
        public int Id;
        public Recurso recurso;
        public Producto producto;
        public int valor;
        public float incrementoNivel;

        public Costo(int id, Recurso rec, Producto producto, int valor, float inc) {
            this.Id = id;
            this.recurso = rec;
            this.producto = producto;
            this.valor = valor;
            this.incrementoNivel = inc;
        }
    }
}