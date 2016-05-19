using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLayer.Admin;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using BLayer.Interfaces;

namespace BLayer
{
    class Program
    {
        public static IGameBuilder blHandler;

        static void Main(string[] args)
        {
 
            //IUnityContainer container = new UnityContainer();
            //container.LoadConfiguration();

           // blHandler = container.Resolve<IGameBuilder>();
            
            //GameBuilderController gbc = new GameBuilderController("nuevojuego", new DALayer.Api.EFApi());
            //gbc.createRecurso("Etherium", "un recurso", null);
 
            GameBuilderController gbc = new GameBuilderController("orgame", new DALayer.Api.EFApi());
            gbc.createRecurso("Etherium", "un recurso", null);
            GameBuilderController gbc2 = new GameBuilderController("orgame2", new DALayer.Api.EFApi());
            gbc2.createRecurso("Etherium2", "un recurso", null);
 
        }
    }
}
