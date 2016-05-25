using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALayer.Interfaces;
using SharedEntities.Entities;

namespace DALayer.Handlers
{
    class UsuarioHandlerEF : IUsuarioHandler
    {
        TenantContext ctx;

        public UsuarioHandlerEF(TenantContext tc)
        {
            ctx = tc;
        }

        public void createAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void createJugador(Jugador jugador)
        {
            throw new NotImplementedException();
        }

        public void deleteAdmin(string id)
        {
            throw new NotImplementedException();
        }

        public void deleteJugador(string id)
        {
            throw new NotImplementedException();
        }

        public Admin getAdmin(string id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> getAllAdmins()
        {
            throw new NotImplementedException();
        }

        public List<Jugador> getAllJugadores()
        {
            throw new NotImplementedException();
        }

        public Jugador getJugador(string id)
        {
            throw new NotImplementedException();
        }

        public void updateAdmin(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void updateJugador(Jugador jugador)
        {
            throw new NotImplementedException();
        }
    }
}
