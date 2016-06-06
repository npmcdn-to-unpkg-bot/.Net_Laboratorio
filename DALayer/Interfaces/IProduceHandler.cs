using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Interfaces
{
    public interface IProduceHandler
    {
        void createProduce(Produce p);
        void deleteProduce(int id);
        void updateProduce(Produce p);
        Produce getProduce(int id);
    }
}
