using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Interfaces
{
    public interface IInteractionHandler
    {
        List<SharedEntities.Entities.Interaction> GetAllInteractions();
        SharedEntities.Entities.Interaction GetInteraction(int id);
        int CreateInteraction(SharedEntities.Entities.Interaction i);
        void UpdateInteraction(SharedEntities.Entities.Interaction i);
        List<Interaction> GetAllInteractionsByColonia(int coloniaId);
    }
}
