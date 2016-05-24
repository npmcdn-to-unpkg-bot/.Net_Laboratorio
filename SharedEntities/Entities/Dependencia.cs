using SharedEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Dependencia
    {
        public int id;
        public int idUnidadDependiente;
        public int idInvestigacionDependiente;
        public int idUniQueDepende;
        public int idInvQueDepende;
        public int level;

        public Dependencia(int id, int idUni, int idInv, int idUQD, int idIQD, int level)
        {
            this.id = id;
            this.idUnidadDependiente = idUni;
            this.idInvestigacionDependiente = idInv;
            this.idUniQueDepende = idUQD;
            this.idInvQueDepende = idIQD;
            this.level = level;
        }

    }
}
