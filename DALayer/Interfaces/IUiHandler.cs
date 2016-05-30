using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IUiHandler
    {
        void createUi(Ui rec);
        void deleteUi(int id);
        void updateUi(Ui rec);
        Ui getUi(int id);
    }
}
