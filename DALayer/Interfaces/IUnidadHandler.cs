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
        int createEdificio(Edificio edificio);
        int createDestacamento(Destacamento destacamento);
        void deleteEdificio(int id);
        void deleteDestacamento(int id);
        void updateEdificio(Edificio edificio);
        void updateDestacamento(Destacamento destacamento);
        List<Edificio> getAllEdificios();
        List<Destacamento> getAllDestacamentos();
        Edificio getEdificio(int id);
        Destacamento getDestacamento(int id);
    }
}
