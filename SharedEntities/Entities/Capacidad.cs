namespace SharedEntities.Entities
{
    public class Capacidad
    {
        public string idRecurso { get; set; }
        public int valor { get; set; }
        public float incrementoNivel { get; set; }

        public Capacidad(string idRecurso, int valor, float inc)
        {
            this.idRecurso = idRecurso;
            this.valor = valor;
            this.incrementoNivel = inc;
        }
    }
}