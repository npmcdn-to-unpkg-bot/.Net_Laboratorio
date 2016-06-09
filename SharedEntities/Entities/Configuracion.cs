using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Configuracion
    {
        public int id;
        public string css;
        public string nombre;
        public string titulo;
        public string idAppFace;
        public string claveAppFace;

        public Configuracion(int id, string css, string nombre, string titulo, string idAppFace, string claveAppFace)
        {
            this.id = id;
            this.css = css;
            this.nombre = nombre;
            this.titulo = titulo;
            this.idAppFace = idAppFace;
            this.claveAppFace = claveAppFace;
        }
    }
}
