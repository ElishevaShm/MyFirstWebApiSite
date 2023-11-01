using System;
using System.Collections.Generic;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Reposirory;

public partial class WebElectricStore1Context : DbContext
{
    public WebElectricStore1Context()
    {
    }

    public WebElectricStore1Context(DbContextOptions<WebElectricStore1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=WebElectricStore1;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0B310C247C");

            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07B48D0798");

            entity.ToTable("Product");

            entity.Property(e => e.Des)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Image)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Categor__286302EC");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("User");

            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
