using System;
using System.Collections.Generic;
using APIProjetoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProjetoFinal.Context;

public partial class Dbg5Context : DbContext
{
    public Dbg5Context()
    {
    }

    public Dbg5Context(DbContextOptions<Dbg5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Calendario> Calendarios { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Categorianota> Categorianotas { get; set; }

    public virtual DbSet<Nota> Notas { get; set; }

    public virtual DbSet<Sharing> Sharings { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NOTE25-S28\\SQLEXPRESS;Initial Catalog=dbg5;User id=sa;Password=Senai@134;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calendario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__calendar__3213E83F582F6A68");

            entity.ToTable("calendario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Atualizacaodata)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("atualizacaodata");
            entity.Property(e => e.Datacriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("datacriacao");
            entity.Property(e => e.Dataevento)
                .HasColumnType("datetime")
                .HasColumnName("dataevento");
            entity.Property(e => e.Descricao)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Tipoevento)
                .IsUnicode(false)
                .HasColumnName("tipoevento");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Calendarios)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK__calendari__iduse__5CD6CB2B");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PK__categori__140587C7BB522468");

            entity.ToTable("categorias");

            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Atualizacaodata)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("atualizacaodata");
            entity.Property(e => e.Criacaodata)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("criacaodata");
            entity.Property(e => e.Nomecategoria)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nomecategoria");
        });

        modelBuilder.Entity<Categorianota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83F7F5F6696");

            entity.ToTable("categorianotas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Notaid).HasColumnName("notaid");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Categorianota)
                .HasForeignKey(d => d.Idcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__categoria__idcat__5812160E");

            entity.HasOne(d => d.Nota).WithMany(p => p.Categorianota)
                .HasForeignKey(d => d.Notaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__categoria__notai__571DF1D5");
        });

        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.Idnota).HasName("PK__notas__60059F493A10D579");

            entity.ToTable("notas");

            entity.Property(e => e.Idnota).HasColumnName("idnota");
            entity.Property(e => e.Datanota)
                .HasColumnType("datetime")
                .HasColumnName("datanota");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Nota1)
                .IsUnicode(false)
                .HasColumnName("nota");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK__notas__iduser__4CA06362");
        });

        modelBuilder.Entity<Sharing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sharing__3213E83FC5510464");

            entity.ToTable("sharing");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Notaid).HasColumnName("notaid");
            entity.Property(e => e.Permissao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("permissao");
            entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");

            entity.HasOne(d => d.Nota).WithMany(p => p.Sharings)
                .HasForeignKey(d => d.Notaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sharing__notaid__4F7CD00D");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Sharings)
                .HasForeignKey(d => d.Usuarioid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sharing__usuario__5070F446");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK__usuario__2A50F1CE73009A3F");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "UQ__usuario__AB6E61640A55B650").IsUnique();

            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nomeuser)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nomeuser");
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("senha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
