namespace SharedEntities.Entities
{
    public class Costo
    {
        string idRecurso { get; set; }
        int valor { get; set; }
        float incrementoNivel { get; set; }

        public Costo(string idRecurso, int valor, float inc) {
            this.idRecurso = idRecurso;
            this.valor = valor;
            this.incrementoNivel = inc;
        }
    }
}