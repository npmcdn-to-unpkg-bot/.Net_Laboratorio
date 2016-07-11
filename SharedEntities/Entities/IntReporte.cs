using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class IntReporte
    {
        public string receiver { get; set; }
        public string requester { get; set; }
        public DateTime Fecha { get; set; }

        public string winner { get; set; }
        public List<States> states { get; set; }

    }
}
