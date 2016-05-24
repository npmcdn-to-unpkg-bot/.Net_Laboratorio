using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Interfaces
{
    public interface ITenantHandler
    {
        bool tenantExist(string id);
    }
}
