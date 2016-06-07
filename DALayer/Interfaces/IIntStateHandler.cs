using DALayer.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IIntStateHandler
    {
        SharedEntities.Entities.IntState GetIntStateByInteraction(int IntId);
        void SaveIntState(SharedEntities.Entities.IntState state);
    }
}
