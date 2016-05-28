﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class RelJugadorInvestigacion
    {
        public int id;
        public RelJugadorMapa colonia;
        public Investigacion investigacion;
        public int nivel;

        public RelJugadorInvestigacion(int ID, RelJugadorMapa col, Investigacion invest, int niv)
        {
            this.id = ID;
            this.colonia = col;
            this.investigacion = invest;
            this.nivel = niv;
        }
    }
}
