using InteractionSdk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Interactuable : IInteractionable
    {
        private bool MustUpdate;
        private int Id;
        private List<IDestacamento> flota = new List<IDestacamento>();
        private List<IDestacamento> defensa = new List<IDestacamento>();
        private List<IResources> recursos = new List<IResources>();
        private int capacidad;
        public bool returnTobase;
        private bool send;
        private bool won = false;
        public Interactuable(int _Id)
        {
            Id = _Id;
            MustUpdate = false;
        }
        public int GetCapacidad()
        {
            return capacidad;
        }

        public List<IDestacamento> GetDefensas()
        {
            return defensa;
        }

        public List<IDestacamento> GetFlota()
        {
            return flota;
        }

        public int GetID()
        {
            return Id;
        }

        public bool GetMustUpdate()
        {
            return MustUpdate;
        }

        public List<IResources> GetRecursos()
        {
            return recursos;
        }

        public void Return()
        {
            returnTobase = true;
        } 
        public void Send()
        {
            send = true;
        }
        public bool mustSend()
        {
            return send;
        }

        public void SetDefensas(List<IDestacamento> ds)
        {
            defensa = ds;
        }

        public void SetFlota(List<IDestacamento> ds)
        {
            flota = ds;
        }

        public void SetMustUpdate(bool v)
        {
            MustUpdate = v;
        }

        public void SetRecursos(List<IResources> rs)
        {
            recursos = rs;
        }

        public void setCapacidad(int cap)
        {
            capacidad = cap;
        }

        public bool getReturn()
        {
            return returnTobase;
        }
        public void Clean() {
            recursos.ForEach((rec) =>
            {
                rec.SetAmount(0);
            });
            flota.ForEach((rec) =>
            {
                rec.SetAmount(0);
            });
            defensa.ForEach((rec) =>
            {
                rec.SetAmount(0);
            });
        }

        public void Win()
        {
            won = true;
        }

        public bool Won()
        {
            return won;
        }
    }
}
