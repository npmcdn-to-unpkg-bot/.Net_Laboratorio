using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IPaquetePayPalHandler
    {
        void createPaquetePaypal(PaquetePaypal pp);
        void deletePaquetePaypal(int id);
        PaquetePaypal getPaquetePaypal(int id);
        List<PaquetePaypal> getAllPaquetes();
        void updatePaquetePaypal(PaquetePaypal pp);
    }
}
