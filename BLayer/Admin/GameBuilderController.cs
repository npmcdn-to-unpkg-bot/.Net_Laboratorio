using BLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLayer.Admin
{
    public class GameBuilderController : IGameBuilder
    {
        String tenantId = null;
        IGameCreation builder;
        public GameBuilderController(string tId, IGameCreation gc) {
            tenantId = tId;
            builder = gc;
        }
        public void createRecurso(string name, string description, byte[] photo)
        {
            throw new NotImplementedException();
        }
    }
}
