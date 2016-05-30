using SharedEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Interfaces
{
    public interface IEstadoInicial
    {
        void createEstadoInicial(EstadoInicialJuego eij);
        void deleteEstadoInicial(int id);
        void updateEstadoInicial(EstadoInicialJuego eij);
        EstadoInicialJuego getEstadoInicial(int id);
        List<EstadoInicialJuego> getAllEstados();
    }
}
