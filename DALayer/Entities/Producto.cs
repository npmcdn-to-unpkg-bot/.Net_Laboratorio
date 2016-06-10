using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DALayer.Entities
{
    public abstract class Producto //Es todo lo que se puede construir, Edificio, Destacamento e Investigacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public byte[] foto { get; set; }
        public virtual List<Costo> costos { get; set; }
        public virtual List<Capacidad> capacidad { get; set; }
        public string tiempoInicial { get; set; }
        public int incrementoTiempo { get; set; }

        public void addCosto(Costo c)
        {
            if (this.costos == null)
            {
                this.costos = new List<Costo>();
            }
            this.costos.Add(c);
        }

        public void setCosto(List<Costo> c)
        {
            this.costos = c;
        }

        public List<Costo> getCosto()
        {
            return this.costos;
        }

        public List<Costo> calCostoXNivel(int nivel, int cant)
        {
            var lista = new List<Costo>();
            foreach (var costo in costos)
            {
                var c = new Costo(costo.recurso, costo.producto, costo.valor, costo.incrementoNivel);
                c.incrementoNivel = costo.incrementoNivel / 100 + 1;
                for (int i = 0; i < nivel; i++)
                {
                    c.valor = Convert.ToInt32(c.valor * c.incrementoNivel);
                }
                c.valor *= cant;
                lista.Add(c);
            }
            return lista;
        }
    }
}