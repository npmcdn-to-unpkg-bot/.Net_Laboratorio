using BLayer.Interfaces;
using DALayer.Interfaces;
using SharedEntities.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLayer.Admin
{
    public class AdminController : IAdmin
    {
        private IApi builder;

        public AdminController(string tId, IApi gc) {
            builder = gc;
            tId = tId.Replace(" ", "_");
            builder.setTenant(tId);
        }

        //TENANT
        public bool existGame(string gameName) {
            return builder.getTenantHandler().tenantExist(gameName);
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

        public void deleteRecurso(int id)
        {
            builder.getRecursoHandler().deleteRecurso(id);
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

        public void deleteMapa(int id)
        {
            builder.getMapaNodeHandler().DeleteMapa(id);
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

        public void deleteInvestigacion(int id)
        {
            builder.getInvestigacionHandler().deleteInvestigacion(id);
        }

        //DESTACAMENTOS
        public List<Destacamento> getAllDestacamentos()
        {
            return builder.getUnidadHandler().getAllDestacamentos();
        }

        public Destacamento getDestacamento(int id)
        {
            return builder.getUnidadHandler().getDestacamento(id);
        }

        public void createDestacamento(Destacamento destacamento)
        {
            builder.getUnidadHandler().createDestacamento(destacamento);
        }

        public void updateDestacamento(Destacamento destacamento)
        {
            builder.getUnidadHandler().updateDestacamento(destacamento);
        }

        public void deleteDestacamento(int id)
        {
            builder.getUnidadHandler().deleteDestacamento(id);
        }

        //EDIFICIOS
        public List<Edificio> getAllEdificios()
        {
            return builder.getUnidadHandler().getAllEdificios();
        }

        public Edificio getEdificio(int id)
        {
            return builder.getUnidadHandler().getEdificio(id);
        }

        public void createEdificio(Edificio edificio)
        {
            builder.getUnidadHandler().createEdificio(edificio);
        }

        public void updateEdificio(Edificio edificio)
        {
            builder.getUnidadHandler().updateEdificio(edificio);
        }

        public void deleteEdificio(int id)
        {
            builder.getUnidadHandler().deleteEdificio(id);
        }

        //ALIANZA
        public List<Alianza> getAllAlianzas()
        {
            return builder.getAlianzaHandler().getAllAlianzas();
        }

        public Alianza getAlianza(int id)
        {
            return builder.getAlianzaHandler().getAlianza(id);
        }

        public void createAlianza(Alianza alianza)
        {
            builder.getAlianzaHandler().createAlianza(alianza);
        }

        public void updateAlianza(Alianza alianza)
        {
            builder.getAlianzaHandler().updateAlianza(alianza);
        }

        public void deleteAlianza(int id)
        {
//            builder.getAlianzaHandler().deleteAlianza(id);
        }

        //DEPENDENCIA
        public List<Dependencia> getAllDependencias()
        {
            return builder.getDependenciaHandler().getAllDependencias();
        }

        public Dependencia getDependencia(int id)
        {
            return builder.getDependenciaHandler().getDependencia(id);
        }

        public void createDependencia(Dependencia dependencia)
        {
            builder.getDependenciaHandler().createDependencia(dependencia);
        }

        public void updateDependencia(Dependencia dependencia)
        {
            builder.getDependenciaHandler().updateDependencia(dependencia);
        }

        public void deleteDependencia(int id)
        {
            builder.getDependenciaHandler().deleteDependencia(id);
        }

        public List<Producto> getAllProductos()
        {
            return builder.getDependenciaHandler().getAllProductos();
        }

        //ESTADO INICIAL JUADOR

        public void inicializarJugador(Jugador j)
        {
            var mapas = builder.getMapaNodeHandler().getAllMapas();
            Random rnd = new Random();
            int[] nivel = { -1, -1, -1, -1, -1 };
            int i = 0;
            string coord = "";
            string c = "/";
            foreach (var m in mapas)
            {
                nivel[i] = rnd.Next(1, m.cantidad+1);
                coord += c;
                c = nivel[i] + "/";
                i++;
            }

            var reljm = new RelJugadorMapa(1, nivel[0], nivel[1], nivel[2], nivel[3], nivel[4], coord, j);
            builder.getRelJugadorMapaHandler().createRelJugadorMapa(reljm);

            List<RelJugadorMapa> colonias = builder.getRelJugadorMapaHandler().getMapasByJugador(j.id);
            var colonia = colonias.First();

            List<Recurso> recursos = builder.getRecursoHandler().getAllRecursos();
            foreach (var rec in recursos)
            {
                var rel = new RelJugadorRecurso(1, rec, colonia, rec.cantInicial, rec.cantInicial, 0);
                builder.getRelJugadorRecursoHandler().createRelJugadorRecurso(rel);
            }

            List<Edificio> edificios = builder.getUnidadHandler().getAllEdificios();
            foreach (var ed in edificios)
            {
                var rel = new RelJugadorEdificio(1, colonia, ed, 0);
                builder.getRelJugadorEdificioHandler().createRelJugadorEdificio(rel);
            }

            List<Destacamento> destacamentos = builder.getUnidadHandler().getAllDestacamentos();
            foreach (var des in destacamentos)
            {
                var rel = new RelJugadorDestacamento(1, colonia, des, 0);
                builder.getRelJugadorDestacamentoHandler().createRelJugadorDestacamento(rel);
            }

            List<Investigacion> investigaciones = builder.getInvestigacionHandler().getAllInvestigaciones();
            foreach (var inv in investigaciones)
            {
                var rel = new RelJugadorInvestigacion(1, colonia, inv, 0);
                builder.getRelJugadorInvestigacionHandler().createRelJugadorInvestigacion(rel);
            }
        }

        //UI
        public Ui getUi(int id)
        {
            return builder.getUiHandler().getUi(id);
        }

        public void createUi(Ui ui)
        {
            builder.getUiHandler().createUi(ui);
        }

        public void updateUi(Ui ui)
        {
            builder.getUiHandler().updateUi(ui);
        }

        public void deleteUi(int id)
        {
            builder.getUiHandler().deleteUi(id);
        }

        public object[] getReporteLogin()
        {
            List<Jugador> jugadores = builder.getUsuarioHandler().getAllJugadores();
            IEnumerable<IGrouping<string, Jugador>> s = jugadores.GroupBy(jugador => (jugador.CreatedDate.Month + " " + jugador.CreatedDate.Year));
            IEnumerator it =  s.GetEnumerator();
            while (it.MoveNext()) {
               object bb=  it.Current;


            }

            return new object[] { };


        }

        //COSTO
        public List<Costo> getAllCostos()
        {
            return builder.getCostoHandler().getAllCostos();
        }

        public Costo getCosto(int id)
        {
            return builder.getCostoHandler().getCosto(id);
        }

        public void createCosto(Costo costo)
        {
            builder.getCostoHandler().createCosto(costo);
        }

        public void updateCosto(Costo costo)
        {
            builder.getCostoHandler().updateCosto(costo);
        }

        public void deleteCosto(int id)
        {
            builder.getCostoHandler().deleteCosto(id);
        }

        //CAPACIDAD
        public List<Capacidad> getAllCapacidades()
        {
            return builder.getCapacidadHandler().getAllCapacidades();
        }

        public Capacidad getCapacidad(int id)
        {
            return builder.getCapacidadHandler().getCapacidad(id);
        }

        public void createCapacidad(Capacidad capacidad)
        {
            builder.getCapacidadHandler().createCapacidad(capacidad);
        }

        public void updateCapacidad(Capacidad capacidad)
        {
            builder.getCapacidadHandler().updateCapacidad(capacidad);
        }

        public void deleteCapacidad(int id)
        {
            builder.getCapacidadHandler().deleteCapacidad(id);
        }
    }
}
