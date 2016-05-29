﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IRelJugadorDestacamentoHandler
    {
        void createRelJugadorDestacamento(RelJugadorDestacamento destacamento);
        void deleteRelJugadorDestacamento(int id);
        void updateRelJugadorDestacamento(RelJugadorDestacamento destacamento);
        RelJugadorDestacamento getRelJugadorDestacamento(int id);
        List<RelJugadorDestacamento> getDestacamentosByColonia(int id);
    }
}
