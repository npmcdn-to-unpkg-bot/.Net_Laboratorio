namespace SharedEntities.Entities
{
    public class Costo
    {
        public int Id;
        public Recurso recurso;
        public int idProducto;
        public int valor;
        public float incrementoNivel;

        public Costo(int id, Recurso rec, int idProducto, int valor, float inc) {
            this.Id = id;
            this.recurso = rec;
            this.idProducto = idProducto;
            this.valor = valor;
            this.incrementoNivel = inc;
        }
    }
}