using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WheelWasteAPI.Model
{
    public partial class hackthon1Context : DbContext
    {
        public hackthon1Context()
        {
        }

        public hackthon1Context(DbContextOptions<hackthon1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Wheel> Wheels { get; set; }
        public virtual DbSet<WheelWasteCollectionDatum> WheelWasteCollectionData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=tcp:hackathon1henrik.database.windows.net,1433;Initial Catalog=hackthon1;Persist Security Info=False;User ID=adminlocal;Password=Password123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Device");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Serial)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Wheel>(entity =>
            {
                entity.ToTable("Wheel");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Wheels)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wheel_Device");
            });

            modelBuilder.Entity<WheelWasteCollectionDatum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.WheelWasteCollectionData)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WheelWasteCollectionData_Device");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WheelWasteCollectionData)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WheelWasteCollectionData_Product");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
