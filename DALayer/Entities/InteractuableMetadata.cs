using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class IneractuableMetadata
    {
        public bool send { get; set; }
        public object[] flota { get; set; }
        public object[] defensa { get; set; }
        public object[] recursos { get; set; }
        public int capacidad { get; set; }
        public int interactuableID { get; set; }
        public bool returnToBase { get; set; }
    }
}
