namespace DALayer
{
    using Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AdminContext : IdentityDbContext<SuperAdmin>
    {
        
        public AdminContext()
            : base("name=Admin")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("Usuario");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UsuarioRol").HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UsuarioLogins").HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UsuarioClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("UsuarioRoles").HasKey<string>(l => l.Id); 
        }

        public virtual DbSet<SolicitudJuego> SolicitudJuego { get; set; }
        public virtual DbSet<Juego> Juego { get; set; }
    }
}