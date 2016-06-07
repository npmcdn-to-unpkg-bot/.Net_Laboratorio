using DALayer.Enum;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    [BsonIgnoreExtraElements]
    public class IntState
    { 
        public int interactionId { get; set; }
        public int receiverId { get; set; }
        public IneractuableMetadata requester { get; set; }
        public IneractuableMetadata receiver { get; set; }
        public InteractionState state { get; set; }
    }
}
