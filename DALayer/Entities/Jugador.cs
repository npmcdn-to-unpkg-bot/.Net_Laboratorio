using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Jugador: Usuario
    {
        public string nickname { get; set; }
        public int nivel { get; set; }
        public float experiencia { get; set; }
    }
}
