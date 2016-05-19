using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLayer.Admin;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using BLayer.Interfaces; 
using DALayer.Interfaces;

namespace BLayer
{
    class Program
    {
        

        static void Main(string[] args)
        {
 
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration();
            //public static IGameBuilder blHandler;
            //GameBuilderController gbc = new GameBuilderController("nuevojuego", new DALayer.Api.EFApi());
            //gbc.createRecurso("Etherium", "un recurso", null);

            GameBuilderController gbc = new GameBuilderController("orgame", container.Resolve<IApi>());
            gbc.createRecurso("Nitrogeno", "un recurso", null);
            GameBuilderController gbc2 = new GameBuilderController("orgame2", container.Resolve<IApi>());
            gbc2.createRecurso("Nitrogeno", "un recurso", null);
 
        }
    }
}
