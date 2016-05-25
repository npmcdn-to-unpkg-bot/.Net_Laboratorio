﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedEntities.Entities
{
    public class Alianza
    {
        public int id;
        public String nombre;
        public List<Jugador> miembros;
        public Jugador admin;
        public String descripcion;
        public byte[] foto;

        public Alianza(int id, string name, List<Jugador> members, Jugador adm, string description, byte[] photo)
        {
            this.id = id;
            this.nombre = name;
            this.miembros = members;
            this.admin = adm;
            this.descripcion = description;
            this.foto = photo;
        }
    }
}
