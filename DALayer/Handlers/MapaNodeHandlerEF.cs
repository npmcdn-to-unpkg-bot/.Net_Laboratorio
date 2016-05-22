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

            ctx.MapaNode.Add(mapaE);
            try
            {

                ctx.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void DeleteMapa(string nombreTmp)
        {
            var mapaE = (from c in ctx.MapaNode
                       where c.nombre == nombreTmp
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
                    MapaNode map = new MapaNode(item.nombre, item.nivel, item.cantidad);
                    mapas.Add(map);
                }
                return mapas;
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
                    .Where(w => w.nombre == mapa.nombre)
                    .SingleOrDefault();

                if (mapaE != null)
                {
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
