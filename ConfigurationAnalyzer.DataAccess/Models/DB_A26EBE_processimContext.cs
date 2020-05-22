using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class DB_A26EBE_processimContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DB_A26EBE_processimContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DB_A26EBE_processimContext(DbContextOptions<DB_A26EBE_processimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProcedureHistory> ProcedureHistory { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<ResourceHistory> ResourceHistory { get; set; }
        public virtual DbSet<ResourceUseHistory> ResourceUseHistory { get; set; }
        public virtual DbSet<SimulationHistory> SimulationHistory { get; set; }
        public virtual DbSet<SimulationName> SimulationName { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Database"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProcedureHistory>(entity =>
            {
                entity.HasIndex(e => e.SimulationHistoryId);

                entity.HasOne(d => d.SimulationHistory)
                    .WithMany(p => p.ProcedureHistory)
                    .HasForeignKey(d => d.SimulationHistoryId);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasIndex(e => e.ResourceCategoryId);

                entity.HasIndex(e => e.ResourceTypeId);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ResourceType)
                    .WithMany(p => p.Resource)
                    .HasForeignKey(d => d.ResourceTypeId);
            });

            modelBuilder.Entity<ResourceHistory>(entity =>
            {
                entity.HasIndex(e => e.SimulationHistoryId);

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.SimulationHistory)
                    .WithMany(p => p.ResourceHistory)
                    .HasForeignKey(d => d.SimulationHistoryId);
            });

            modelBuilder.Entity<ResourceType>(entity =>
            {
                entity.HasIndex(e => e.ResourceCategoryId);
            });

            modelBuilder.Entity<ResourceUseHistory>(entity =>
            {
                entity.HasIndex(e => e.ResourceHistoryId);

                entity.HasOne(d => d.ResourceHistory)
                    .WithMany(p => p.ResourceUseHistory)
                    .HasForeignKey(d => d.ResourceHistoryId);
            });

            modelBuilder.Entity<SimulationHistory>(entity =>
            {
                entity.HasIndex(e => e.SimulationNameId);

                entity.Property(e => e.DateTime).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.SimulationName)
                    .WithMany(p => p.SimulationHistory)
                    .HasForeignKey(d => d.SimulationNameId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
