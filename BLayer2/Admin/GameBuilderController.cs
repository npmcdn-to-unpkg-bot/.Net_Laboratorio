using BLayer.Interfaces;
using DALayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLayer.Admin
{
    public class GameBuilderController : IGameBuilder
    {
        private IApi builder;

        public GameBuilderController(string tId, IApi gc) {
            builder = gc;
            builder.setTenant(tId);
        }

        //RECURSOS
        public List<Recurso> getAllRecursos()
        {
            return builder.getRecursoHandler().getAllRecursos();
        }

        public Recurso getRecurso(int id)
        {
            return builder.getRecursoHandler().getRecurso(id);
        }

        public void createRecurso(Recurso recurso)
        {
            builder.getRecursoHandler().createRecurso(recurso);
        }

        public void updateRecurso(Recurso recurso)
        {
            builder.getRecursoHandler().updateRecurso(recurso);
        }

        public void deleteRecurso(Recurso recurso)
        {
            builder.getRecursoHandler().deleteRecurso(recurso);
        }

        //MAPAS
        public List<MapaNode> getAllMapas()
        {
            return builder.getMapaNodeHandler().getAllMapas();
        }
        public MapaNode getMapa(int id)
        {
            return builder.getMapaNodeHandler().getMapa(id);
        }

        public void createMapa(MapaNode mapa)
        {
            builder.getMapaNodeHandler().CreateMapa(mapa);
        }

        public void deleteMapa(MapaNode mapa)
        {
            builder.getMapaNodeHandler().DeleteMapa(mapa);
        }

        public void updateMapa(MapaNode mapa)
        {
            builder.getMapaNodeHandler().UpdateMapa(mapa);
        }

        //INVESTIGACION
        public List<Investigacion> getAllInvestigaciones()
        {
            return builder.getInvestigacionHandler().getAllInvestigaciones();
        }

        public Investigacion getInvestigacion(int id)
        {
            return builder.getInvestigacionHandler().getInvestigacion(id);
        }

        public void createInvestigacion(Investigacion investigacion)
        {
            builder.getInvestigacionHandler().createInvestigacion(investigacion);
        }

        public void updateInvestigacion(Investigacion investigacion)
        {
            builder.getInvestigacionHandler().updateInvestigacion(investigacion);
        }

        public void deleteInvestigacion(Investigacion investigacion)
        {
            builder.getInvestigacionHandler().deleteInvestigacion(investigacion);
        }
    }
}
