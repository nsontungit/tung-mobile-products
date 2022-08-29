using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace entities.main
{
    public partial class productsContext : DbContext
    {
        public productsContext()
        {
        }

        public productsContext(DbContextOptions<productsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FlywaySchemaHistory> FlywaySchemaHistory { get; set; }
        public virtual DbSet<Laptops> Laptops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3309;user=root;password=123456;database=products");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlywaySchemaHistory>(entity =>
            {
                entity.HasKey(e => e.InstalledRank)
                    .HasName("PRIMARY");

                entity.ToTable("flyway_schema_history");

                entity.HasIndex(e => e.Success)
                    .HasName("flyway_schema_history_s_idx");

                entity.Property(e => e.InstalledRank).HasColumnName("installed_rank");

                entity.Property(e => e.Checksum).HasColumnName("checksum");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.ExecutionTime).HasColumnName("execution_time");

                entity.Property(e => e.InstalledBy)
                    .IsRequired()
                    .HasColumnName("installed_by")
                    .HasMaxLength(100);

                entity.Property(e => e.Script)
                    .IsRequired()
                    .HasColumnName("script")
                    .HasMaxLength(1000);

                entity.Property(e => e.Success).HasColumnName("success");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(20);

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Laptops>(entity =>
            {
                entity.ToTable("laptops");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brand)
                    .HasColumnName("brand")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Ram).HasColumnName("RAM");

                entity.Property(e => e.Resolution)
                    .IsRequired()
                    .HasColumnName("resolution")
                    .HasMaxLength(250);

                entity.Property(e => e.Rom).HasColumnName("ROM");

                entity.Property(e => e.ScreenSize)
                    .HasColumnName("screen_size")
                    .HasColumnType("float(2,2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
