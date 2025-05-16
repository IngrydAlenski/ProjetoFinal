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

    private IConfiguration _configuration;
    public Dbg5Context(DbContextOptions<Dbg5Context> options, IConfiguration config)
        : base(options)
    {
        _configuration = config;    
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Categorianota> Categorianotas { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Nota> Notas { get; set; }

    public virtual DbSet<Sharing> Sharings { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var con = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(con);
    }
      
    //=> optionsBuilder.UseSqlServer("Data Source=NOTE10-S28\\SQLEXPRESS;Initial Catalog=dbg5;User id=sa;Password=Senai@134;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PK__categori__140587C7366217FC");

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
            entity.HasKey(e => e.Idnotacategoria).HasName("PK__categori__DBEBC2B20460096E");

            entity.ToTable("categorianotas");

            entity.Property(e => e.Idnotacategoria).HasColumnName("idnotacategoria");
            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Notaid).HasColumnName("notaid");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Categorianota)
                .HasForeignKey(d => d.Idcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__categoria__idcat__59063A47");

            entity.HasOne(d => d.Nota).WithMany(p => p.Categorianota)
                .HasForeignKey(d => d.Notaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__categoria__notai__5812160E");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Idevento).HasName("PK__evento__C8A2BCFE8C8DDECC");

            entity.ToTable("evento");

            entity.Property(e => e.Idevento).HasColumnName("idevento");
            entity.Property(e => e.Descricaoevento)
                .HasColumnType("text")
                .HasColumnName("descricaoevento");
            entity.Property(e => e.Tipoevento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipoevento");
        });

        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.Idnota).HasName("PK__notas__60059F490941A56C");

            entity.ToTable("notas");

            entity.Property(e => e.Idnota).HasColumnName("idnota");
            entity.Property(e => e.Atualizacaonota)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("atualizacaonota");
            entity.Property(e => e.Datanota)
                .HasColumnType("datetime")
                .HasColumnName("datanota");
            entity.Property(e => e.Descricao)
                .HasColumnType("text")
                .HasColumnName("descricao");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Titulonota)
                .HasColumnType("text")
                .HasColumnName("titulonota");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK__notas__iduser__4D94879B");
        });

        modelBuilder.Entity<Sharing>(entity =>
        {
            entity.HasKey(e => e.Idsharing).HasName("PK__sharing__1FEC517DBDF36F4E");

            entity.ToTable("sharing");

            entity.Property(e => e.Idsharing).HasColumnName("idsharing");
            entity.Property(e => e.Notaid).HasColumnName("notaid");
            entity.Property(e => e.Permissao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("permissao");
            entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");

            entity.HasOne(d => d.Nota).WithMany(p => p.Sharings)
                .HasForeignKey(d => d.Notaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sharing__notaid__5070F446");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Sharings)
                .HasForeignKey(d => d.Usuarioid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__sharing__usuario__5165187F");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK__usuario__2A50F1CE81888EBC");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "UQ__usuario__AB6E61644048B066").IsUnique();

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
