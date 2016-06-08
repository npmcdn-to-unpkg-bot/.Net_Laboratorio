using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class InteractuableMetadata
    {
        public int interactuableID;

        public object[] flota { get; set; }
        public object[] defensa { get; set; }
        public object[] recursos { get; set; }
        public int capacidad { get; set; }
        public bool returnToBase { get; set; }
        public bool send { get; set; }
    }
}
