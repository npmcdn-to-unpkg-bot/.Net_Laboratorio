using InteractionSdk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataque.Entities
{
    public class Unidad
    {

        private float DamageTaken {get;set;}
        private float DamageTakenRound {get;set;}
        private bool destroyed = false;
        private IDestacamento dest;
        public Unidad(IDestacamento _des) {
            this.dest = _des;
        }

        public bool Hit(float Damage) {
            if (DamageTaken == 0)
            {
                if (dest.GetEscudo() < DamageTakenRound + Damage)
                {
                    DamageTaken = DamageTakenRound + Damage - dest.GetEscudo();
                }
                else {
                    DamageTakenRound = +Damage;
                }
            } else {

                DamageTaken+=Damage;
            }
            if (DamageTaken >= dest.GetVida()) {
                destroyed = true;
            }
            return destroyed;
        }
        public void RestoreShield() {
            DamageTakenRound = 0;
        }

        internal int GetId()
        {
            return dest.GetId();
        }
    }
}
