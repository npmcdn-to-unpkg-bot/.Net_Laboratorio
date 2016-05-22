using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IJuegoHandler
    {
        void createJuego(Juego game);
        void deleteJuego(int id);
        void updateJuego(Juego game);
        Juego getJuego(int id);
        List<Juego> getAllJuegos();
    }
}
