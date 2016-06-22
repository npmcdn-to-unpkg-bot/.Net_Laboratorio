using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLayer.Interfaces;
using DALayer.Interfaces;
using SharedEntities.Entities;
using InteractionSdk.Interfaces;

namespace BLayer.Front
{
    public class FrontController : IFront
    {
        private IApi builder;

        public FrontController(string tId, IApi gc)
        {
            builder = gc;
            tId = tId.Replace(" ", "_");
            builder.setTenant(tId);

           // testIntearction();


        }

        //private void testIntearction() {
        //    string player1 = "f9103cac-7347-45d3-b5ef-4df04a408912";
        //    string player2 = "f136d9c4-c0c1-4138-882c-e54784e9035b";
        //    RelJugadorMapa player1Mapa = builder.getRelJugadorMapaHandler().getMapasByJugador(player1).First();
        //    RelJugadorMapa player2Mapa =  builder.getRelJugadorMapaHandler().getMapasByJugador(player2).First();
        //    Interactuable requester = new Interactuable(player1Mapa.id);
        //    requester.SetFlota(getDestacamentosByColonia(player1Mapa.id).Cast<IDestacamento>().ToList());
        //    var rlist = getRecursosByColonia(player1Mapa.id).Cast<IResources>().ToList();
        //    rlist.ForEach((c) =>
        //    {
        //        c.SetAmount(0);
        //    });
        //    requester.SetRecursos(rlist);
        //    Interactuable receiver = new Interactuable(player2Mapa.id);
        //    receiver.SetFlota(getDestacamentosByColonia(player2Mapa.id).Cast<IDestacamento>().ToList());
        //    receiver.SetRecursos(getRecursosByColonia(player2Mapa.id).Cast<IResources>().ToList());
        //    InteractionController ic = new InteractionController();
        //    ic.LoadInteractionByName("");
        //    ic.InitializeInteraction(requester, receiver);
        //}

        //TENANT
        public bool existGame(string gameName)
        {
            return builder.getTenantHandler().tenantExist(gameName);
        }

        //RELJUGADORRECURSOS
        public RelJugadorRecurso getRelJugadorRecurso(int id)
        {
            return builder.getRelJugadorRecursoHandler().getRelJugadorRecurso(id);
        }

        public void createRelJugadorRecurso(RelJugadorRecurso reljugadorrecurso)
        {
            builder.getRelJugadorRecursoHandler().createRelJugadorRecurso(reljugadorrecurso);
        }

        public void updateRelJugadorRecurso(RelJugadorRecurso reljugadorrecurso)
        {
            builder.getRelJugadorRecursoHandler().updateRelJugadorRecurso(reljugadorrecurso);
        }

        public void deleteRelJugadorRecurso(int id)
        {
            builder.getRelJugadorRecursoHandler().deleteRelJugadorRecurso(id);
        }

        public List<RelJugadorRecurso> getRecursosByColonia(int id)
        {
            return builder.getRelJugadorRecursoHandler().getRecursosByColonia(id);
        }

        //RELJUGADOREDIFICIOS
        public RelJugadorEdificio getRelJugadorEdificio(int id)
        {
            return builder.getRelJugadorEdificioHandler().getRelJugadorEdificio(id);
        }

        public void createRelJugadorEdificio(RelJugadorEdificio reljugadoredificio)
        {
            builder.getRelJugadorEdificioHandler().createRelJugadorEdificio(reljugadoredificio);
        }

        public RelJugadorEdificio subirNivelRelJE(int id)
        {
            return builder.getRelJugadorEdificioHandler().subirNivel(id);
        }

        public void executeSubirRelJE(int idRel)
        {
            builder.getRelJugadorEdificioHandler().executeSubirRelJE(idRel);
        }

        public void bajarNivel(int id)
        {
            builder.getRelJugadorEdificioHandler().bajarNivel(id);
        }

        public List<RelJugadorEdificio> getEdificiosByColonia(int id)
        {
            return builder.getRelJugadorEdificioHandler().getEdificiosByColonia(id);
        }

        //RELJUGADORINVESTIGACION
        public RelJugadorInvestigacion getRelJugadorInvestigacion(int id)
        {
            return builder.getRelJugadorInvestigacionHandler().getRelJugadorInvestigacion(id);
        }

        public void createRelJugadorInvestigacion(RelJugadorInvestigacion reljugadorinvestigacion)
        {
            builder.getRelJugadorInvestigacionHandler().createRelJugadorInvestigacion(reljugadorinvestigacion);
        }

        public void updateRelJugadorInvestigacion(RelJugadorInvestigacion reljugadorinvestigacion)
        {
            builder.getRelJugadorInvestigacionHandler().updateRelJugadorInvestigacion(reljugadorinvestigacion);
        }

        public void deleteRelJugadorInvestigacion(int id)
        {
            builder.getRelJugadorInvestigacionHandler().deleteRelJugadorInvestigacion(id);
        }

        public List<RelJugadorInvestigacion> getInvestigacionesByColonia(int id)
        {
            return builder.getRelJugadorInvestigacionHandler().getInvestigacionesByColonia(id);
        }

        public RelJugadorInvestigacion subirNivelI(int id)
        {
            return builder.getRelJugadorInvestigacionHandler().subirNivelI(id);
        }

        public void executeSubirRelJI(int idRel)
        {
            builder.getRelJugadorInvestigacionHandler().executeSubir(idRel);
        }

        public void bajarNivelI(int id)
        {
            builder.getRelJugadorInvestigacionHandler().bajarNivelI(id);
        }

        //RELJUGADORMAPAS
        public RelJugadorMapa getRelJugadorMapa(int id)
        {
            return builder.getRelJugadorMapaHandler().getRelJugadorMapa(id);
        }

        public void createRelJugadorMapa(RelJugadorMapa reljugadormapa)
        {
            builder.getRelJugadorMapaHandler().createRelJugadorMapa(reljugadormapa);
        }

        public void updateRelJugadorMapa(RelJugadorMapa reljugadormapa)
        {
            builder.getRelJugadorMapaHandler().updateRelJugadorMapa(reljugadormapa);
        }

        public void deleteRelJugadorMapa(int id)
        {
            builder.getRelJugadorMapaHandler().deleteRelJugadorMapa(id);
        }

        public List<RelJugadorMapa> getMapasByJugador(string id)
        {
            return builder.getRelJugadorMapaHandler().getMapasByJugador(id);
        }

        public List<RelJugadorMapa> getColoniasPorVista(int[] coordenadas)
        {
            return builder.getRelJugadorMapaHandler().getColoniasPorVista(coordenadas);
        }

        //RELJUGADORDESTACAMENTOS
        public RelJugadorDestacamento getRelJugadorDestacamento(int id)
        {
            return builder.getRelJugadorDestacamentoHandler().getRelJugadorDestacamento(id);
        }

        public void createRelJugadorDestacamento(RelJugadorDestacamento reljugadordestacamento)
        {
            builder.getRelJugadorDestacamentoHandler().createRelJugadorDestacamento(reljugadordestacamento);
        }

        public void updateRelJugadorDestacamento(RelJugadorDestacamento reljugadoredificio)
        {
            builder.getRelJugadorDestacamentoHandler().updateRelJugadorDestacamento(reljugadoredificio);
        }

        public List<RelJugadorDestacamento> getDestacamentosByColonia(int id)
        {
            return builder.getRelJugadorDestacamentoHandler().getDestacamentosByColonia(id);
        }

        public void subirCantidadDestacamento(int id, int sube)
        {
            builder.getRelJugadorDestacamentoHandler().subirCantidadDestacamento(id, sube);
        }

        public void executeUpdateRelJD(RelJugadorDestacamento rel)
        {
            builder.getRelJugadorDestacamentoHandler().executeUpdateRelJD(rel);
        }

        public void bajarCantidadDestacamento(int id, int baja)
        {
            builder.getRelJugadorDestacamentoHandler().bajarCantidadDestacamento(id, baja);
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

        public Alianza getAlianzaByAdministrador(string id)
        {
            Alianza alianza = builder.getAlianzaHandler().getAlianzaByAdministrador(id);
            if(alianza == null)
            {
                return builder.getRelJugadorAlianzaHandler().getAlianzaByMiembro(id);
            }

            return alianza;
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
            builder.getAlianzaHandler().deleteAlianza(id);
        }

        //RELJUGADORALIANZA
        public RelJugadorAlianza getRelJugadorAlianza(int id)
        {
            return builder.getRelJugadorAlianzaHandler().getRelJugadorAlianza(id);
        }

        public void createRelJugadorAlianza(RelJugadorAlianza reljugadoralianza)
        {
            builder.getRelJugadorAlianzaHandler().createRelJugadorAlianza(reljugadoralianza);
        }

        public void updateRelJugadorAlianza(RelJugadorAlianza reljugadoralianza)
        {
            builder.getRelJugadorAlianzaHandler().updateRelJugadorAlianza(reljugadoralianza);
        }

        public void deleteRelJugadorAlianza(int id)
        {
            builder.getRelJugadorAlianzaHandler().deleteRelJugadorAlianza(id);
        }

        public List<RelJugadorAlianza> getAllRelJugadorAlianza()
        {
            return builder.getRelJugadorAlianzaHandler().getAllRelJugadorAlianza();
        }

        public List<RelJugadorAlianza> getMiembrosByAlianza(int id)
        {
            return builder.getRelJugadorAlianzaHandler().getMiembrosByAlianza(id);
        }

        //Jugador logueado
        public Jugador getJugador(string id)
        {
            return builder.getUsuarioHandler().getJugador(id);
        }

    }
}
