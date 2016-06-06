using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLayer.Interfaces
{
    public interface IAdmin
    {
        // RECURSO
        List<Recurso> getAllRecursos();
        void createRecurso(Recurso recurso);
        void deleteRecurso(int id);
        void updateRecurso(Recurso recurso);
        Recurso getRecurso(int id);

        //Registro login
        void registerLogin(string id);

        //REPORTES
        List<object> getReporteLogin();
        List<object> getReporteRegistro();

        //MAPA
        List<MapaNode> getAllMapas();
        void createMapa(MapaNode mapa);
        MapaNode getMapa(int id);
        void deleteMapa(int id);
        void updateMapa(MapaNode mapa);

        //INVESTIGACION
        List<Investigacion> getAllInvestigaciones();
        void createInvestigacion(Investigacion investigacion);
        void deleteInvestigacion(int id);
        void updateInvestigacion(Investigacion investigacion);
        Investigacion getInvestigacion(int id);

        // DESTACAMENTO
        List<Destacamento> getAllDestacamentos();
        void createDestacamento(Destacamento destacamento);
        void deleteDestacamento(int id);
        void updateDestacamento(Destacamento destacamento);
        Destacamento getDestacamento(int id);

        // EDIFICIO
        List<Edificio> getAllEdificios();
        void createEdificio(Edificio edificio);
        void deleteEdificio(int id);
        void updateEdificio(Edificio edificio);
        Edificio getEdificio(int id);

        // ALIANZA
        List<Alianza> getAllAlianzas();
        void createAlianza(Alianza alianza);
        void deleteAlianza(int id);
        void updateAlianza(Alianza alianza);
        Alianza getAlianza(int id);

        // DEPENDENCIA
        List<Dependencia> getAllDependencias();
        void createDependencia(Dependencia dependencia);
        void deleteDependencia(int id);
        void updateDependencia(Dependencia dependencia);
        Dependencia getDependencia(int id);
        List<Producto> getAllProductos();

        //ESTADO INICIAL JUGADOR
        void inicializarJugador(Jugador j);

        // RECURSO
        void createUi(Ui ui);
        void deleteUi(int id);
        void updateUi(Ui ui);
        Ui getUi(int id);

        //COSTO
        void createCosto(Costo costo);
        void deleteCosto(int id);
        void updateCosto(Costo costo);
        Costo getCosto(int id);

        //CAPACIDAD
        void createCapacidad(Capacidad capacidad);
        void deleteCapacidad(int id);
        void updateCapacidad(Capacidad capacidad);
        Capacidad getCapacidad(int id);

        //PRODUCE
        void createProduce(Produce p);
        void deleteProduce(int id);
        void updateProduce(Produce p);
        Produce getProduce(int id);
    }
}
