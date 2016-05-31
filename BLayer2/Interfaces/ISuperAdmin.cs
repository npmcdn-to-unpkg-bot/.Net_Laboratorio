using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Interfaces
{
    public interface ISuperAdmin
    {
        void createSolicitud(SharedEntities.Entities.SolicitudJuego sol);
        string getActivateURL(SharedEntities.Entities.SolicitudJuego sol);
    }
}
