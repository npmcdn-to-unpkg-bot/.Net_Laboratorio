namespace SharedEntities.Entities
{
    public class Dependencia
    {
        public int id;
        public int padreId;
        public int hijoId;
        public int nivel;
        public Producto padre;
        public Producto hijo;


        public Dependencia(int id, Producto padre, int padreId, Producto hijo, int hijoId, int nivel)
        {
            this.id = id;
            this.padreId = padreId;
            this.padre = padre;
            this.hijoId = hijoId;
            this.hijo = hijo;
            this.nivel = nivel;
        }
    }
}
