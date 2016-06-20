using DALayer.Interfaces;
using SharedEntities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DALayer.Handlers
{
    public class InteractionHandler : IInteractionHandler
    {
        private TenantContext ctx;

        public InteractionHandler(TenantContext ctx)
        {
            this.ctx = ctx;
        }

        public int CreateInteraction(Interaction shared)
        {
            DALayer.Entities.Interaction data = InteractionHandler.SharedToData(shared);
            ctx.Interaction.Add(data);
            ctx.SaveChanges();
            return data.Id;
        }
        
        public List<Interaction> GetAllInteractions()
        {
            List<Interaction> ret = new List<Interaction>();

            ctx.Interaction.ToList().ForEach((data) => {
                ret.Add(InteractionHandler.DataToShared(data));
            });
            return ret;
        }

        public List<Interaction> GetAllInteractionsByColonia(int coloniaId)
        {
            List<Interaction> ret = new List<Interaction>();

            ctx.Interaction.Where(c => c.receiverId == coloniaId).ToList().ForEach((data) => {
                ret.Add(InteractionHandler.DataToShared(data));
            });
            return ret;
        }

        public Interaction GetInteraction(int id)
        {
            DALayer.Entities.Interaction data = ctx.Interaction.Where(c => c.Id == id).First();
            if (data != null)
            {
                return InteractionHandler.DataToShared(data);
            }
            else {
                return null;
            }

        }
        public void UpdateInteraction(Interaction shared)
        {
            ctx.Interaction.Add(InteractionHandler.SharedToData(shared));
            ctx.SaveChanges();
        }

        public static Interaction DataToShared(DALayer.Entities.Interaction data)
        {
            Interaction shared = new Interaction();
            shared.Id = data.Id;
            shared.Fecha = data.Fecha;
            shared.receiverId = data.receiverId;
            shared.requesterId = data.requesterId;
            shared.intName = data.intName;
            return shared;
        }
        public static DALayer.Entities.Interaction SharedToData(Interaction shared)
        {
            DALayer.Entities.Interaction data = new DALayer.Entities.Interaction();
            data.Id = shared.Id;
            data.Fecha = shared.Fecha;
            data.receiverId = shared.receiverId;
            data.requesterId = shared.requesterId;
            data.intName = shared.intName;
            return data;
        }
       
    }
}
