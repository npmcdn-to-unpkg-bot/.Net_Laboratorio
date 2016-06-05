namespace SharedEntities.Entities
{
    public class Capacidad
    {
        public int Id;
        public Recurso recurso;
        public int valor;
        public float incrementoNivel;

        public Capacidad(Recurso rec, int valor, float inc)
        {
            this.recurso = rec;
            this.valor = valor;
            this.incrementoNivel = inc;
        }
    }
}