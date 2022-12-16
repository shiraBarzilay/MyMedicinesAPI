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

    public virtual DbSet<UsersTbl> UsersTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("MyDBConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
