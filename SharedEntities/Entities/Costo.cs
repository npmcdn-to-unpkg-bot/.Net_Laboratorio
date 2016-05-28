namespace SharedEntities.Entities
{
    public class Costo
    {
        public string idRecurso { get; set; }
        public int valor { get; set; }
        public float incrementoNivel { get; set; }

        public Costo(string idRecurso, int valor, float inc) {
            this.idRecurso = idRecurso;
            this.valor = valor;
            this.incrementoNivel = inc;
        }
    }
}