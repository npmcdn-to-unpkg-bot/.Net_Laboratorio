using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Interaction
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int requesterId { get; set; }
        public int receiverId { get; set; }
       // public virtual List<IntState> states { get; set; }
        public bool confirmed { get; set; }
        //dll name
        public string intName { get; set; }
    }
}
