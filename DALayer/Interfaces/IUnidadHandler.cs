using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IUnidadHandler
    {
        void createEdificio(Edificio edificio);
        void createDestacamento(Destacamento destacamento);
        void deleteEdificio(Edificio edificio);
        void deleteDestacamento(Destacamento destacamento);
        void updateEdificio(Edificio edificio);
        void updateDestacamento(Destacamento destacamento);
        List<Edificio> getAllEdificios();
        List<Destacamento> getAllDestacamentos();
        Edificio getEdificio(int id);
        Destacamento getDestacamento(int id);
    }
}
