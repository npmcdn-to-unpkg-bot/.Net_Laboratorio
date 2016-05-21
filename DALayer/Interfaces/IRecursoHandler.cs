﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;

namespace DALayer.Interfaces
{
    public interface IRecursoHandler
    {
        void createRecurso(Recurso rec);
        void deleteRecurso(Recurso rec);
        void updateRecurso(Recurso rec);
        List<Recurso> getAllRecursos();
        Recurso getRecurso(Guid id);
    }
}
