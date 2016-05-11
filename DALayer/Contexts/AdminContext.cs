namespace DALayer
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AdminContext : DbContext
    {
       // private const String schema = "atlas.admin";
        // Your context has been configured to use a 'Admin' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DALayer.Admin' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Admin' 
        // connection string in the application configuration file.
        public AdminContext()
            : base("name=Admin")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<SuperAdmin> SuperAdmins { get; set; }
        public virtual DbSet<SolicitudJuego> SolicitudJuegos { get; set; }
        public virtual DbSet<Juego> Juego { get; set; }
    }
}