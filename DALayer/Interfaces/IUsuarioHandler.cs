using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Interfaces
{
    public interface IUsuarioHandler
    {
        void createJugador(Jugador jugador);
        void createAdmin(Admin admin);
        void deleteJugador(string id);
        void deleteAdmin(string id);
        void updateJugador(Jugador jugador);
        void updateAdmin(Admin admin);
        List<Jugador> getAllJugadores();
        List<Admin> getAllAdmins();
        Jugador getJugador(string id);
        Admin getAdmin(string id);
    }
}
