using SharedEntities.Entities;
using SharedEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.DataTypes
{
    public class RecursoInfo :IRecursoInfo
    {
        private float cantidad;
        private Recurso recurso;
        public RecursoInfo(Recurso r) {
            recurso = r;
        }

        float IRecursoInfo.cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }
         
    }
}
