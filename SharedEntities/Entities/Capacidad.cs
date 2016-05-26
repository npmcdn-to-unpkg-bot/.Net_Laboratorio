namespace SharedEntities.Entities
{
    public class Capacidad
    {
        string idRecurso { get; set; }
        int valor { get; set; }
        float incrementoNivel { get; set; }

        public Capacidad(string idRecurso, int valor, float inc)
        {
            this.idRecurso = idRecurso;
            this.valor = valor;
            this.incrementoNivel = inc;
        }
    }
}