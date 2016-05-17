using BLayer.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer2
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBuilderController gbc = new GameBuilderController("nuevojuego", new DALayer.Api.EFApi());
            gbc.createRecurso("Etherium", "un recurso", null);
        }
    }
}
