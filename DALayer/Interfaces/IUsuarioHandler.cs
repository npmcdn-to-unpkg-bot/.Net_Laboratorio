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
        void deleteJugador(int id);
        void deleteAdmin(int id);
        void updateJugador(Jugador jugador);
        void updateAdmin(Admin admin);
        List<Jugador> getAllJugadores();
        List<Admin> getAllAdmins();
        Jugador getJugador(int id);
        Admin getAdmin(int id);
    }
}
