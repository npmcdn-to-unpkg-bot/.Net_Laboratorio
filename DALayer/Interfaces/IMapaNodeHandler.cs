using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IMapaNodeHandler
    {
        void CreateMapa(MapaNode mapa);
        void DeleteMapa(string nombreTmp);
        void UpdateMapa(MapaNode mapa);
        List<MapaNode> getAllMapas();
    }
}
