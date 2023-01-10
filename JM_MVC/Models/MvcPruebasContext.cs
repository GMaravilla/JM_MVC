using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JM_MVC.Models;

public partial class MvcPruebasContext : DbContext
{
    public MvcPruebasContext()
    {
    }

    public MvcPruebasContext(DbContextOptions<MvcPruebasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Balero> Baleros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-72OA6OB; Database=MvcPruebas; Trusted_Connection=True; Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Balero>(entity =>
        {
            entity.HasKey(e => e.IdBaleros).HasName("PK__Baleros__AA2084F9A2EC0CED");

            entity.Property(e => e.Codigo)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Create");
            entity.Property(e => e.Marca)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(5, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
