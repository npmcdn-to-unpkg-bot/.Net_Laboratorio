using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Investigacion : Producto
    {
        public Investigacion() { }

        public Investigacion(string nombre, string descripcion, byte[] foto)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.foto = foto;
        }

        public SharedEntities.Entities.Investigacion getShared()
        {
            var costosS = new List<SharedEntities.Entities.Costo>();
            foreach (var c in costos)
            {
                var cS = new SharedEntities.Entities.Costo(c.Id, c.recurso.getShared(), c.recurso.id, c.valor, c.incrementoNivel);
                costosS.Add(cS);
            } 
            var investigacion = new SharedEntities.Entities.Investigacion(id, nombre, descripcion, foto, costosS);
            return investigacion;
        }
    }
}
