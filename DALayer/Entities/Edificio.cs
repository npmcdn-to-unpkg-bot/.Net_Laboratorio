using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Entities
{
    public class Edificio : Unidad
    {

        public Edificio(string nombre, string descripcion, byte[] foto, List<SharedEntities.Entities.Costo> costo1, List<SharedEntities.Entities.Capacidad> capacidad1, float ataque, float escudo, float efectividadAtaque, float vida)
        {
            List<Costo> cos = new List<Costo>();
            foreach (var item in costo1)
            {
                var c = new Costo(item.idRecurso, item.valor, item.incrementoNivel);
                cos.Add(c);
            }
            List<Capacidad> cap = new List<Capacidad>();
            foreach (var item in capacidad1)
            {
                var c = new Capacidad(item.idRecurso, item.valor, item.incrementoNivel);
                cap.Add(c);
            }

            this.nombre = nombre;
            this.descripcion = descripcion;
            this.foto = foto;
            this.costo = cos;
            this.capacidad = cap;
            this.ataque = ataque;
            this.escudo = escudo;
            this.efectividadAtaque = efectividadAtaque;
            this.vida = vida;
        }
    }
}
