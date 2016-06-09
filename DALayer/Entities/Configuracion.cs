using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Configuracion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nombre { get; set; }
        public string titulo { get; set; }
        public string css { get; set; }
        public string idAppFace { get; set; }
        public string claveAppFace { get; set; }

        public Configuracion() { }

        public Configuracion(string css, string nombre, string titulo, string idAppFace, string claveAppFace)
        {
            this.css = css;
            this.nombre = nombre;
            this.titulo = titulo;
            this.idAppFace = idAppFace;
            this.claveAppFace = claveAppFace;
        }

        public SharedEntities.Entities.Configuracion getShared()
        {
            return new SharedEntities.Entities.Configuracion(id, css, nombre, titulo, idAppFace, claveAppFace);
        }
    }
}
