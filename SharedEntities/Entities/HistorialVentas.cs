using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class HistorialVentas
    {
        public int id;
        public int idusuario;
        public string nombreOferta;
        public DateTime fechaCompra;

        public HistorialVentas(int ident, int iduser, string nameO, DateTime dateB)
        {
            this.id = ident;
            this.idusuario = iduser;
            this.nombreOferta = nameO;
            this.fechaCompra = dateB;
        }
    }
}
