using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLayer.Interfaces
{
    public interface IGameBuilder
    {

        void createRecurso(string name, string description, byte[] photo);
    }
}
