using System.Collections.Generic;

namespace SharedEntities.Entities
{
    public class InteractuableDT
    {
        public int id { get; set; }
        public List<Tupla> flota {get; set; }
        public List<Tupla> recurso { get; set; }
}
}