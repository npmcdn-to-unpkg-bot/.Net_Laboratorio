namespace DALayer
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AdminContext : DbContext
    {
        
        public AdminContext()
            : base("name=Admin")
        {
        } 

        public virtual DbSet<SuperAdmin> SuperAdmins { get; set; }
        public virtual DbSet<SolicitudJuego> SolicitudJuego { get; set; }
        public virtual DbSet<Juego> Juego { get; set; }
    }
}