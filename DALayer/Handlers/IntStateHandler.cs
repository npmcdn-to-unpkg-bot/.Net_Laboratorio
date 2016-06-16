using DALayer.Contexts; 
using DALayer.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using SharedEntities.Entities;

namespace DALayer.Handlers
{
    public class IntStateHandler : IIntStateHandler
    {
        private string schemaName;
        private MongoCtx ctx;
        public IntStateHandler(string schemaName)
        {
            ctx = new MongoCtx(schemaName);
            this.schemaName = schemaName;
        }

        public IntState GetIntStateByInteraction(int IntId)
        {
            BsonDocument doc = ctx.GetIntState(IntId);
            DALayer.Entities.IntState intState = BsonSerializer.Deserialize<DALayer.Entities.IntState>(doc);
            return DataToShared(intState);
        }
        public void SaveIntState(IntState state)
        {

            BsonDocument doc = SharedToData(state).ToBsonDocument();
            ctx.SaveCurrent(doc);
        }
        public static InteractuableMetadata DataToShared(DALayer.Entities.IneractuableMetadata data)
        {
            InteractuableMetadata shared = new InteractuableMetadata();
            shared.capacidad = data.capacidad;
            shared.defensa = data.defensa;
            shared.flota = data.flota;
            shared.recursos = data.recursos;
            shared.returnToBase = data.returnToBase; 
            shared.interactuableID = data.interactuableID;
            shared.send = data.send;
            return shared;
        }
        public static IntState DataToShared(DALayer.Entities.IntState data)
        {
            IntState shared = new IntState();
            shared.interactionId = data.interactionId;
            shared.receiver = data.receiver != null ? DataToShared(data.receiver) : null;
            shared.receiverId = data.receiverId;
            shared.requester = DataToShared(data.requester);
            shared.winnerId = data.winnerId;
            switch (data.state)
            {
                case DALayer.Enum.InteractionState.EXECUTING:
                    shared.state = SharedEntities.Enum.InteractionState.EXECUTING;
                    break;
                case DALayer.Enum.InteractionState.FINISH:
                    shared.state = SharedEntities.Enum.InteractionState.EXECUTING;
                    break;
                case DALayer.Enum.InteractionState.FINISHING:
                    shared.state = SharedEntities.Enum.InteractionState.FINISHING;
                    break;
            }
            return shared;
        }
        public static DALayer.Entities.IneractuableMetadata SharedToData(InteractuableMetadata shared)
        {
            DALayer.Entities.IneractuableMetadata data = new DALayer.Entities.IneractuableMetadata();
            data.capacidad = shared.capacidad;
            data.defensa = shared.defensa;
            data.flota = shared.flota;
            data.recursos = shared.recursos;
            data.returnToBase = shared.returnToBase;
            data.interactuableID = shared.interactuableID;
            data.send = shared.send;
            return data;
        }
        public static DALayer.Entities.IntState SharedToData(SharedEntities.Entities.IntState shared)
        {
            DALayer.Entities.IntState data = new DALayer.Entities.IntState();
            data.interactionId = shared.interactionId;
            data.receiver = shared.receiver != null ? SharedToData(shared.receiver) : null;
            data.receiverId = shared.receiverId;
            data.requester = SharedToData(shared.requester);
            data.winnerId = shared.winnerId;
            switch (shared.state) {
                case SharedEntities.Enum.InteractionState.EXECUTING:
                    data.state = DALayer.Enum.InteractionState.EXECUTING;
                    break;
                case SharedEntities.Enum.InteractionState.FINISH:
                    data.state = DALayer.Enum.InteractionState.EXECUTING;
                    break;
                case SharedEntities.Enum.InteractionState.FINISHING:
                    data.state = DALayer.Enum.InteractionState.FINISHING;
                    break;
            }
           
            return data;
        }
    }
}
