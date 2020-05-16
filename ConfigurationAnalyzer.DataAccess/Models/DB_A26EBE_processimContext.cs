using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConfigurationAnalyzer.DataAccess.Models
{
    public partial class DB_A26EBE_processimContext : DbContext
    {
        public DB_A26EBE_processimContext()
        {
        }

        public DB_A26EBE_processimContext(DbContextOptions<DB_A26EBE_processimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<ProcedureHistory> ProcedureHistory { get; set; }
        public virtual DbSet<RandomEventHistory> RandomEventHistory { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<ResourceCategory> ResourceCategory { get; set; }
        public virtual DbSet<ResourceHistory> ResourceHistory { get; set; }
        public virtual DbSet<ResourceParameter> ResourceParameter { get; set; }
        public virtual DbSet<ResourceParameterValue> ResourceParameterValue { get; set; }
        public virtual DbSet<ResourceType> ResourceType { get; set; }
        public virtual DbSet<ResourceUseHistory> ResourceUseHistory { get; set; }
        public virtual DbSet<SimulationHistory> SimulationHistory { get; set; }
        public virtual DbSet<SimulationName> SimulationName { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SQL6009.site4now.net;Initial Catalog=DB_A26EBE_processim;User Id=DB_A26EBE_processim_admin;Password=jtt2fp2msl;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<ProcedureHistory>(entity =>
            {
                entity.HasIndex(e => e.SimulationHistoryId);

                entity.HasOne(d => d.SimulationHistory)
                    .WithMany(p => p.ProcedureHistory)
                    .HasForeignKey(d => d.SimulationHistoryId);
            });

            modelBuilder.Entity<RandomEventHistory>(entity =>
            {
                entity.HasIndex(e => e.ProcedureHistoryId);

                entity.HasOne(d => d.ProcedureHistory)
                    .WithMany(p => p.RandomEventHistory)
                    .HasForeignKey(d => d.ProcedureHistoryId);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasIndex(e => e.ResourceCategoryId);

                entity.HasIndex(e => e.ResourceTypeId);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ResourceCategory)
                    .WithMany(p => p.Resource)
                    .HasForeignKey(d => d.ResourceCategoryId);

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

            modelBuilder.Entity<ResourceParameter>(entity =>
            {
                entity.HasIndex(e => e.ResourceTypeId);

                entity.HasOne(d => d.ResourceType)
                    .WithMany(p => p.ResourceParameter)
                    .HasForeignKey(d => d.ResourceTypeId);
            });

            modelBuilder.Entity<ResourceParameterValue>(entity =>
            {
                entity.HasIndex(e => e.ResourceId);

                entity.HasIndex(e => e.ResourceParameterId);

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ResourceParameterValue)
                    .HasForeignKey(d => d.ResourceId);

                entity.HasOne(d => d.ResourceParameter)
                    .WithMany(p => p.ResourceParameterValue)
                    .HasForeignKey(d => d.ResourceParameterId);
            });

            modelBuilder.Entity<ResourceType>(entity =>
            {
                entity.HasIndex(e => e.ResourceCategoryId);

                entity.HasOne(d => d.ResourceCategory)
                    .WithMany(p => p.ResourceType)
                    .HasForeignKey(d => d.ResourceCategoryId);
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
