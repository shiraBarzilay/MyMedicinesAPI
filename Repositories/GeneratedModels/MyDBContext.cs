using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repositories.GeneratedModels
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MedicinesTbl> MedicinesTbls { get; set; } = null!;
        public virtual DbSet<UsersTbl> UsersTbls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("MyDBConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicinesTbl>(entity =>
            {
                entity.HasKey(e => e.MedicineId)
                    .HasName("MedicinesTbl_pkey");

                entity.ToTable("MedicinesTbl");

                entity.Property(e => e.MedicineId).UseIdentityAlwaysColumn();

                entity.Property(e => e.MedicineNameEnglish).HasColumnType("character varying");

                entity.Property(e => e.MedicineNameHebrew).HasColumnType("character varying");

                entity.Property(e => e.MedicineUrlImage).HasColumnType("character varying");
            });

            modelBuilder.Entity<UsersTbl>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("UsersTbl_pkey");

                entity.ToTable("UsersTbl");

                entity.Property(e => e.UserId).UseIdentityAlwaysColumn();

                entity.Property(e => e.IsActive).HasColumnType("bit(1)");

                entity.Property(e => e.UserAddress).HasColumnType("character varying");

                entity.Property(e => e.UserEmail).HasColumnType("character varying");

                entity.Property(e => e.UserFirstName).HasColumnType("character varying");

                entity.Property(e => e.UserLastName).HasColumnType("character varying");

                entity.Property(e => e.UserUniqueId).HasColumnType("character varying");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
