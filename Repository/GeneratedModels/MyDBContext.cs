using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repository.GeneratedModels;

public partial class MyDBContext : DbContext
{
    public MyDBContext()
    {
    }

    public MyDBContext(DbContextOptions<MyDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MedicinesTbl> MedicinesTbls { get; set; }

    public virtual DbSet<UserMedicinesTbl> UserMedicinesTbls { get; set; }

    public virtual DbSet<UsersTbl> UsersTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("MyDBConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicinesTbl>(entity =>
        {
            entity.HasKey(e => e.MedicineId).HasName("MedicinesTbl_pkey");

            entity.ToTable("MedicinesTbl");

            entity.Property(e => e.MedicineId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UserMedicinesTbl>(entity =>
        {
            entity.HasKey(e => e.UserMedicineId).HasName("UserMedicinesTbl_pkey");

            entity.ToTable("UserMedicinesTbl");

            entity.Property(e => e.UserMedicineId).ValueGeneratedNever();

            entity.HasOne(d => d.Medicine).WithMany(p => p.UserMedicinesTbls)
                .HasForeignKey(d => d.MedicineId)
                .HasConstraintName("MedicinesTbl");

            entity.HasOne(d => d.User).WithMany(p => p.UserMedicinesTbls)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UsersTbl");
        });

        modelBuilder.Entity<UsersTbl>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("UsersTbl_pkey");

            entity.ToTable("UsersTbl");

            entity.Property(e => e.UserId).UseIdentityAlwaysColumn();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
