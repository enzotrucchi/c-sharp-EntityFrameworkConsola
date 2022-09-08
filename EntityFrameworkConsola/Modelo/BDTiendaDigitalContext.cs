using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameworkConsola.Modelo
{
    public partial class BDTiendaDigitalContext : DbContext
    {
        
        public BDTiendaDigitalContext()
        {
        }

        public BDTiendaDigitalContext(DbContextOptions<BDTiendaDigitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Rubro> Rubros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ENZO\\SQLEXPRESS; Database=BDTiendaDigital; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdRubro).HasColumnName("idRubro");

                entity.HasOne(d => d.IdRubroNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdRubro)
                    .HasConstraintName("FK_Producto_Rubro");
            });

            modelBuilder.Entity<Rubro>(entity =>
            {
                entity.ToTable("Rubro");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .HasColumnName("descripcion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
