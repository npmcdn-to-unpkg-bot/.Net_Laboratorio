using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Interfaces
{
    public interface IInteraccion
    {
        String getName();
        void init(IEntidadInteraccion sender, IEntidadInteraccion receptor);
        void setUp(IEntidadConfig senderSttgs, IEntidadConfig receptorSttgs);
        void run();
    }
}
