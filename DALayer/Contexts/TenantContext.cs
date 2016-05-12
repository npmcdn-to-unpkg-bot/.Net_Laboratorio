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
        public virtual DbSet<Recurso> Recurso { get; set; }
    }
}
