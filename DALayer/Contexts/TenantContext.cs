namespace DALayer
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    public class TenantContext : DbContext, IDbModelCacheKeyProvider
    {

        private String SchemaName;
        public TenantContext(string connection, String TennantId)
            : base(connection)
        {  
            this.SchemaName = TennantId; 
        }
        public TenantContext(string connection, DbCompiledModel model, String TennantId)
           : base(connection, model)
        {

            this.SchemaName = TennantId;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types()
              .Configure(c => c.ToTable(c.ClrType.Name, this.SchemaName)); 
        }

        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Recurso> Recurso { get; set; }
        public virtual DbSet<MapaNode> MapaNode { get; set; }
        public virtual DbSet<Alianza> Alianza { get; set; }
        public virtual DbSet<Dependencia> Dependencia { get; set; }
        public virtual DbSet<Destacamento> Destacamento { get; set; }
        public virtual DbSet<Edificio> Edificio { get; set; }
        public virtual DbSet<Costo> Costo { get; set; }
        public virtual DbSet<Capacidad> Capacidad { get; set; }
        public virtual DbSet<Flota> Flota { get; set; }
        public virtual DbSet<Investigacion> Investigacion { get; set; }
        public virtual DbSet<PaquetePaypal> PaquetePaypal { get; set; }
        public virtual DbSet<HistorialVentas> HistorialVentas { get; set; }
        public virtual DbSet<EstadoInicialJuego> EstadoInicialJuego { get; set; }

        public string CacheKey
        {
            get
            {
                return this.SchemaName;
            }
        }
    }
}
