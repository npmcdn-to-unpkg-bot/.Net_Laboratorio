using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Interfaces;
using SharedEntities.Entities;
using System.Data.Entity.Validation;

namespace DALayer.Handlers
{
    public class MapaNodeHandlerEF : IMapaNodeHandler
    {
        TenantContext ctx;
        public MapaNodeHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }
        public void CreateMapa(MapaNode mapa)
        {
            Entities.MapaNode mapaE = new Entities.MapaNode();
            mapaE.nombre = mapa.nombre;
            mapaE.nivel = mapa.nivel;
            mapaE.cantidad = mapa.cantidad;

            try
            {
                ctx.MapaNode.Add(mapaE);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteMapa(int id)
        {
            var mapaE = (from c in ctx.MapaNode
                       where c.id == id
                       select c).SingleOrDefault();
            try
            {
                ctx.MapaNode.Remove(mapaE);
                ctx.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MapaNode> getAllMapas()
        {
            List<MapaNode> mapas = new List<MapaNode>();
            try
            {
                List<Entities.MapaNode> mapasE = ctx.MapaNode.ToList();
                foreach (Entities.MapaNode item in mapasE)
                {
                    MapaNode map = new MapaNode(item.id, item.nombre, item.nivel, item.cantidad);
                    mapas.Add(map);
                }
                return mapas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MapaNode getMapa(int id)
        {
            try
            {
                var map = (from c in ctx.MapaNode
                           where c.id == id
                           select c).SingleOrDefault();

                MapaNode mapa = new MapaNode(map.id, map.nombre, map.nivel, map.cantidad);
                return mapa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateMapa(MapaNode mapa)
        {
            try
            {
                var mapaE = ctx.MapaNode
                    .Where(w => w.id == mapa.id)
                    .SingleOrDefault();

                if (mapaE != null)
                {
                    mapaE.nombre = mapa.nombre;
                    mapaE.nivel = mapa.nivel;
                    mapaE.cantidad = mapa.cantidad;
                    ctx.SaveChangesAsync().Wait();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
