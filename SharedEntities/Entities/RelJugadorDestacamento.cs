using InteractionSdk.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class RelJugadorDestacamento: IDestacamento
    {
        public int id;
        public RelJugadorMapa colonia;
        public Destacamento destacamento;
        public int cantidad;

        public RelJugadorDestacamento(int ID, RelJugadorMapa col, Destacamento desta, int cant)
        {
            this.id = ID;
            this.colonia = col;
            this.destacamento = desta;
            this.cantidad = cant;
        }

        public float GetAtaque()
        {
            return destacamento.ataque;
        }

        public float GetEscudo()
        {
            return destacamento.escudo;
        }

        public float GetEfectividad()
        {
            return destacamento.efectividadAtaque;
        }

        public float GetVida()
        {
            return destacamento.vida;
        }

        public float GetVelocidad()
        {
            return destacamento.velocidad;
        }

        public string GetName()
        {
            return destacamento.nombre;
        }

        public int GetAmount()
        {
            return cantidad;
        }
        public void SetAmount(int i)
        {
            cantidad = i;
        }
        public int GetId()
        {
            return destacamento.id;
        }
        public int GetCapacidad() {
            int capacidadTotal = 0;
            destacamento.capacidad.ForEach((c) =>
            {
                capacidadTotal = +c.valor;
            });
            return capacidadTotal * cantidad;
        }
    }
}
