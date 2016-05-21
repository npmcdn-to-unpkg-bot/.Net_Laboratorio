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
        Edificio createEdificio(Edificio edificio);
        Destacamento createDestacamento(Destacamento destacamento);
        void deleteEdificio(Edificio edificio);
        void deleteDestacamento(Destacamento destacamento);
        Edificio updateEdificio(Edificio edificio);
        Destacamento updateDestacamento(Destacamento destacamento);
        List<Edificio> getAllEdificios();
        List<Destacamento> getAllDestacamentos();
        Edificio getEdificio(Guid id);
        Destacamento getDestacamento(Guid id);
    }
}
