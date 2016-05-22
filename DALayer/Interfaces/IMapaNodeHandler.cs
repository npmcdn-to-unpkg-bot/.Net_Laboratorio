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
        void DeleteMapa(MapaNode mapa);
        void UpdateMapa(MapaNode mapa);
        MapaNode getMapa(int id);
        List<MapaNode> getAllMapas();
    }
}
