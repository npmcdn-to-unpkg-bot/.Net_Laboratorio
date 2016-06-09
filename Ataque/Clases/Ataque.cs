using Ataque.Entities;
using InteractionSdk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ataque.Clases
{
    public class Ataque : IInteraction
    {
        List<Unidad> FlotaAtacadaRequester = new List<Unidad>();
        List<Unidad> FlotaAtacadaReceiver = new List<Unidad>();
        Dictionary<int, int> destacamento = new Dictionary<int, int>();
        Dictionary<int, int> recurso = new Dictionary<int, int>();

        private int GetAtaquesEfectivos(IDestacamento des) {
            int ataquesEfectivos = 0;

            if (des.GetEfectividad() == 100)
            {
                return des.GetAmount();
            }
            if (des.GetAmount() >= 100)
            {

                ataquesEfectivos = Convert.ToInt32(Math.Truncate(des.GetAmount() * des.GetEfectividad()/100));
            }
            else {
                for (var i = 0; i < des.GetAmount(); i++) {
                    Random rdm = new Random();
                    var dice = rdm.Next(0, 99);
                    if (dice <= des.GetEfectividad())
                    {
                        ataquesEfectivos++;
                    }
                }
            }
            return ataquesEfectivos;
        }
        private float GetInitiative(IInteractionable i) {
            Random rdm = new Random();
            float requesterDice = rdm.Next(1, 20);
            float initiative = 0;
            i.GetFlota().ForEach((flota) => {
                initiative += (flota.GetAmount() * flota.GetVelocidad() / 1000);
            });
            i.GetDefensas().ForEach((def) =>
            {
                initiative += (def.GetAmount() * def.GetEfectividad()) / 100;
            });
            return requesterDice + initiative;
        }

        private int FlotaAmount(IInteractionable i) {
            var amount = 0;
            i.GetFlota().ForEach((flota) => {
                amount += flota.GetAmount();
            });
            i.GetDefensas().ForEach((def) =>
            {
                amount += def.GetAmount();
            });
            return amount;
        }
        private int AttackDamaged(List<Unidad> DamagedUnits, int AmountAttacks, float damage, IInteractionable i) {
            int PerformedAttacks = 0;
            int index = 0;
            while (DamagedUnits.Count > 0 && PerformedAttacks < AmountAttacks) {
                Unidad u = DamagedUnits.ElementAt(index);
                bool destroyed = u.Hit(damage);
                if (destroyed)
                {
                    IDestacamento d = i.GetDefensas().Concat(i.GetFlota()).Where(c => c.GetId() == u.GetId()).First<IDestacamento>();
                    d.SetAmount(d.GetAmount() - 1);
                    DamagedUnits.Remove(u);
                }
                else {
                    //DamagedUnits.Insert(index, u);
                }
                PerformedAttacks++;
                index = index + 1 > DamagedUnits.Count - 1 ? 0 : index + 1; 
            }
            return AmountAttacks - PerformedAttacks;
        }
        private void PerformAttack(IDestacamento d, IInteractionable i , bool isReq) {
            int AmountAttacks = GetAtaquesEfectivos(d);
            List<Unidad> damagedUnits = isReq ? FlotaAtacadaRequester : FlotaAtacadaReceiver;
            int targetselector = AttackDamaged(damagedUnits, AmountAttacks, d.GetAtaque(), i);
            int nexToAttack = targetselector;
            if (targetselector > 0)
            {
                IEnumerable<IDestacamento> it = i.GetFlota().Concat(i.GetDefensas()).OrderBy(c => c.GetEscudo());
                List<IDestacamento> targets = it.TakeWhile((flota) =>
                {
                    if (targetselector == 0) return false;

                    if (targetselector <= flota.GetAmount())
                    {
                        targetselector = 0;
                        return true;
                    }
                    else {
                        targetselector -= flota.GetAmount();
                        return true;
                    }
                }).ToList();
                targets.ForEach((t) => {
                    int index = 0;
                    int large = t.GetAmount();
                    while (nexToAttack > 0 && index < large)
                    {
                        Unidad u = new Unidad(t);
                        bool destroyed = u.Hit(d.GetAtaque());
                        if (!destroyed)
                        {
                            damagedUnits.Add(u);
                        }
                        else {
                            t.SetAmount(t.GetAmount()-1);
                        }
                        index++;
                        nexToAttack--;
                    }
                });
                if(nexToAttack != 0)
                {
                    AttackDamaged(damagedUnits, nexToAttack, d.GetAtaque(), i);
                }
            }
        }
        public IConfig GetConfig()
        {
            return new Config();
        }

        public List<IInteractionable> initialize(IInteractionable requester, IInteractionable receiver)
        {
            requester.Send();
            return new List<IInteractionable> { requester, receiver };
        }

        public List<IInteractionable> exec(IInteractionable requester, IInteractionable receiver)
        {

            receiver.GetFlota().ForEach((c) =>
            {
                destacamento.Add(c.GetId(), c.GetAmount());
            });
            receiver.GetDefensas().ForEach((c) =>
            {
                destacamento.Add(c.GetId(), c.GetAmount());
            });
            receiver.GetRecursos().ForEach((c) =>
            {
                recurso.Add(c.GetId(), c.GetAmount());
            }); 
         

            bool requesterWin = false;
            float round = 0;
            while (!requesterWin && FlotaAmount(requester) >0) {
                System.Diagnostics.Debug.WriteLine("####Round" + round);
                round++;
                float receiverDice = GetInitiative(receiver);
                float requesterDice = GetInitiative(requester);
                //restore shield 
                FlotaAtacadaReceiver.ForEach((u) => { u.RestoreShield(); });
                FlotaAtacadaRequester.ForEach((u) => { u.RestoreShield(); });
                var FlotaRapidaRequester = requester.GetFlota().OrderBy(c => c.GetVelocidad() * c.GetAmount()).Where(c=>c.GetAmount() != 0);
                var FlotaRapidaReceiver = receiver.GetFlota().Concat(receiver.GetDefensas()).OrderBy(c => c.GetVelocidad() * c.GetAmount()).Where(c => c.GetAmount() != 0); ;
                if (requesterDice >= receiverDice)
                {
                    FlotaRapidaRequester.ToList().ForEach((c) => {
                    PerformAttack(c, receiver, false);
                    });
                    FlotaRapidaReceiver.ToList().ForEach((c) => {
                        PerformAttack(c, requester, true);
                    });
                }
                else {
                    FlotaRapidaReceiver.ToList().ForEach((c) => {
                        PerformAttack(c, requester, true);
                    });
                    FlotaRapidaRequester.ToList().ForEach((c) => {
                        PerformAttack(c, receiver, false);
                    });

                }
                requesterWin = FlotaAmount(receiver) == 0;
            }
            if (requesterWin) {
                requester.GetFlota().ForEach((des) =>
                {
                    var capacidad= des.GetCapacidad() / receiver.GetRecursos().Count;
                    receiver.GetRecursos().ForEach((rec) => {
                        var setter = requester.GetRecursos().Where(c => c.GetId() == rec.GetId()).First();
                        if (rec.GetAmount() < capacidad)
                        {
                            setter.SetAmount(setter.GetAmount() + rec.GetAmount());
                        }
                        else {
                            setter.SetAmount(setter.GetAmount() + capacidad); 
                        }
                    });

                });
                requester.Return();
            }
            destacamento.ToList().ForEach((r)=>{
               IDestacamento defensa = receiver.GetDefensas().Where(c => c.GetId() == r.Key).FirstOrDefault();
                if(defensa != null)
                {

                    defensa.SetAmount(defensa.GetAmount() - r.Value);
                }
            });
            destacamento.ToList().ForEach((r) => {
                IDestacamento flota = receiver.GetFlota().Where(c => c.GetId() == r.Key).FirstOrDefault();
                if (flota != null) {

                    flota.SetAmount(flota.GetAmount() - r.Value);
                }
            });
            recurso.ToList().ForEach((r) => {
                IResources rec = receiver.GetRecursos().Where(c => c.GetId() == r.Key).FirstOrDefault();
                if(rec != null)
                {

                    rec.SetAmount(rec.GetAmount() - r.Value);
                }
            });
            receiver.SetMustUpdate(true);
            return new List<IInteractionable> { requester, receiver };
        }

        public List<IInteractionable> finalize(IInteractionable requester, IInteractionable receiver)
        {
            requester.SetMustUpdate(true);
            return new List<IInteractionable> { requester, receiver };
        }

       
    }
}
