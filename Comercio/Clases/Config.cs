using InteractionSdk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.Clases
{
    public class Config : IConfig
    {
        private const string name = "Comercio";
        public string GetName()
        {
            return name;
        }

        public bool isRecNeedFloat()
        {
            return false;
        }

        public bool isRecNeedRecursos()
        {
            return false;
        }

        public bool isReqNeedFloat()
        {
            return true;
        }

        public bool isReqNeedRecursos()
        {
            return true;
        }

        public bool NeedConfirmation()
        {
            return false;
        }

    }
}
