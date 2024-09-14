using System;
using System.Collections.Generic;
using APIPRUEBAS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIPRUEBAS.Models;

public partial class BbContext : DbContext
{
    public BbContext()
    {
    }

    public BbContext(DbContextOptions<BbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; } = null!;
    public virtual DbSet<Producto> Producto { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria)
            .HasName("PK__CATEGORI__A3C02A10BC340243");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto)
            .HasName("PK__PRODUCTO__098892103AA8B03B");

            entity.HasOne(d => d.oCategoria)
            .WithMany(p => p.Producto)
            .HasForeignKey(d => d.IdCategoria)
            .HasConstraintName("FK_IDCATEGORIA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
