namespace DALayer
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class TenantContext : DbContext, IDbModelCacheKeyProvider
    {

        private String SchemaName;
        public TenantContext(string connectionString, String TennantId)
            : base(connectionString)
        {
            this.SchemaName = TennantId;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(this.SchemaName);
        }
        public string CacheKey
        {
            get { return this.SchemaName; }
        }
        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Recurso> Recurso { get; set; }
        public virtual DbSet<MapaNode> MapaNode { get; set; }
        public virtual DbSet<Alianza> Alianza { get; set; }
        public virtual DbSet<Dependencia> Dependencia { get; set; }
        public virtual DbSet<Destacamento> Destacamento { get; set; }
        public virtual DbSet<Edificio> Edificio { get; set; }
        public virtual DbSet<Flota> Flota { get; set; }
        public virtual DbSet<Investigacion> Investigacion { get; set; }
        public virtual DbSet<PaquetePaypal> PaquetePaypal { get; set; }
        public virtual DbSet<HistorialVentas> HistorialVentas { get; set; }
        public virtual DbSet<EstadoInicialJuego> EstadoInicialJuego { get; set; }
    }
}
