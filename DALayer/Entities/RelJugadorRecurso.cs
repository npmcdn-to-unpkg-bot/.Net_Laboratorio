﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedEntities.Entities;

namespace DALayer.Entities
{
    public class RelJugadorRecurso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public virtual Recurso recurso { get; set; }
        public virtual RelJugadorMapa colonia { get; set; }
        public int capacidad { get; set; }
        public int cantidadR { get; set; }
        public float produccionXTiempo { get; set; }
        public DateTime ultimaConsulta { get; set; }

        public RelJugadorRecurso() { }

        public RelJugadorRecurso(Recurso r, RelJugadorMapa c, int capacidad, int cantidadR, float produccionXTiempo, DateTime ultimaConsulta)
        {
            this.recurso = r;
            this.colonia = c;
            this.capacidad = capacidad;
            this.cantidadR = cantidadR;
            this.produccionXTiempo = produccionXTiempo;
            this.ultimaConsulta = ultimaConsulta;
        }

        public SharedEntities.Entities.RelJugadorRecurso getShared()
        {
            return new SharedEntities.Entities.RelJugadorRecurso(id, recurso.getShared(), colonia.getShared(), capacidad, cantidadR,
                produccionXTiempo, ultimaConsulta);
        }
    }

}
