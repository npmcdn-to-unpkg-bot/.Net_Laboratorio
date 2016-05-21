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
        void deletePaquetePaypal(string nombreO);
        List<PaquetePaypal> getAllPaquetes();
        void updatePaquetePaypal(PaquetePaypal pp);
    }
}
