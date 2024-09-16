using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sgiTechStore.Models;

public partial class SgiTechStoreContext : DbContext
{
    public SgiTechStoreContext()
    {
    }

    public SgiTechStoreContext(DbContextOptions<SgiTechStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProdXCat> ProdXCats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-G9ASMNR\\SQLEXPRESS;Database=sgiTechStore;Integrated Security=true;TrustServerCertificate=True;Command Timeout=300");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCat).HasName("PK__Categori__D54686DED5DFA4C3");

            entity.Property(e => e.IdCat).HasColumnName("id_cat");
            entity.Property(e => e.NombCat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nomb_cat");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProd).HasName("PK__Producto__0DA34873C0463F71");

            entity.Property(e => e.IdProd).HasColumnName("id_prod");
            entity.Property(e => e.DescripProd)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descrip_prod");
            entity.Property(e => e.FechaFabricacion).HasColumnName("fecha_fabricacion");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.NombProd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nomb_prod");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<ProdXCat>(entity =>
        {
            entity.HasKey(e => e.IdPxc).HasName("PK__Producto__6FC9988C4F301AFD");

            entity.ToTable("ProductosXCategorias");

            entity.Property(e => e.IdPxc).HasColumnName("id_pxc");
            entity.Property(e => e.IdCat).HasColumnName("id_cat");
            entity.Property(e => e.IdProd).HasColumnName("id_prod");

            entity.HasOne(d => d.IdCatNavigation).WithMany(p => p.ProductosXcategoria)
                .HasForeignKey(d => d.IdCat)
                .HasConstraintName("FK__Productos__id_ca__6754599E");

            entity.HasOne(d => d.IdProdNavigation).WithMany(p => p.ProductosXcategoria)
                .HasForeignKey(d => d.IdProd)
                .HasConstraintName("FK__Productos__id_pr__68487DD7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
