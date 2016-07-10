using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Enum;

namespace SharedEntities.Entities
{
    public class States
    {
        public InteractionState state;
        public Interactuable rec { get; set; }
        public Interactuable req { get; set; }
     }
}
