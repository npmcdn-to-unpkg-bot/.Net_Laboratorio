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
        public void CreateMapa(MapaNode m)
        {
            var mapaE = new Entities.MapaNode(m.nombre, m.nivel, m.cantidad, m.distance);

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
            var mapasS = new List<MapaNode>();
            try
            {
                var mapasE = ctx.MapaNode.ToList();
                foreach (var item in mapasE)
                {
                    mapasS.Add(item.getShared());
                }
                return mapasS;
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
                
                return map.getShared();
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
                    mapaE.distance = mapa.distance;
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
