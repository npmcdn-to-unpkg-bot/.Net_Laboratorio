using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SharedEntities.Entities;

namespace DALayer.Entities
{
    public class RelJugadorAlianza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public virtual Alianza alianza { get; set; }
        public virtual Jugador miembro { get; set; }
        public bool activo { get; set; }


        public RelJugadorAlianza() { }

        public RelJugadorAlianza(Alianza alianza, Jugador miembro, bool activo)
        {
            this.alianza = alianza;
            this.miembro = miembro;
            this.activo = activo;
        }

        public SharedEntities.Entities.RelJugadorAlianza getShared()
        {
            var rel = new SharedEntities.Entities.RelJugadorAlianza(id, alianza.getShared(), miembro.getShared(), activo);
            return rel;
        }
    }
}
