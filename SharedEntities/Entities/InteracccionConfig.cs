using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class InteraccionConfig
    {
        public string tipo { get; set; }
        public InteractuableDT requester { get; set; }
        public InteractuableDT receiver { get; set; }
    }
}
