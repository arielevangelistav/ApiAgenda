using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiAgenda.Models;

public partial class MiAgendaContext : DbContext
{
    public MiAgendaContext()
    {
    }

    public MiAgendaContext(DbContextOptions<MiAgendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sesione> Sesiones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sesione>(entity =>
        {
            entity.HasKey(e => e.IdSesiones).HasName("PK__Sesiones__16104DE977FB06F8");

            entity.Property(e => e.IdSesiones).HasColumnName("Id_Sesiones");
            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuarios).HasName("PK__Usuarios__AEF9042959D4E5D7");

            entity.Property(e => e.IdUsuarios).HasColumnName("Id_Usuarios");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
