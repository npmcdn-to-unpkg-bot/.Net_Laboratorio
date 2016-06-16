using SharedEntities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class IntState
    {
        public int winnerId { get; set; }
        public int interactionId { get; set; }
        public int receiverId { get; set; }
        public InteractuableMetadata requester { get; set; }
        public InteractuableMetadata receiver { get; set; }
        public InteractionState state { get; set; }
    }
}
