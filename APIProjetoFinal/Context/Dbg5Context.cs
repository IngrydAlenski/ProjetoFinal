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

    public virtual DbSet<AuditoriaGeral> AuditoriaGerals { get; set; }

    public virtual DbSet<Calendario> Calendarios { get; set; }

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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditoriaGeral>(entity =>
        {
            entity.HasKey(e => e.IdAuditoria).HasName("PK__Auditori__7FD13FA0B63DE6D0");

            entity.ToTable("AuditoriaGeral");

            entity.Property(e => e.DataAcao).HasColumnType("datetime");
            entity.Property(e => e.NomeTabela)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoAcao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Calendario>(entity =>
        {
            entity.HasKey(e => e.Idcalendario).HasName("PK__calendar__BF7461472ED64C49");

            entity.ToTable("calendario", tb => tb.HasTrigger("trg_audit_calendario"));

            entity.Property(e => e.Idcalendario).HasColumnName("idcalendario");
            entity.Property(e => e.Atualizacaodata)
                .HasColumnType("datetime")
                .HasColumnName("atualizacaodata");
            entity.Property(e => e.Datacriacao)
                .HasColumnType("datetime")
                .HasColumnName("datacriacao");
            entity.Property(e => e.Dataevento)
                .HasColumnType("datetime")
                .HasColumnName("dataevento");
            entity.Property(e => e.Descricao)
                .IsUnicode(false)
                .HasColumnName("descricao");
            entity.Property(e => e.Idevento).HasColumnName("idevento");
            entity.Property(e => e.Iduser).HasColumnName("iduser");

            entity.HasOne(d => d.IdeventoNavigation).WithMany(p => p.Calendarios)
                .HasForeignKey(d => d.Idevento)
                .HasConstraintName("FK__calendari__ideve__797309D9");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Calendarios)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK__calendari__iduse__787EE5A0");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PK__categori__140587C7115049D3");

            entity.ToTable("categorias", tb => tb.HasTrigger("trg_audit_categorias"));

            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Atualizacaodata)
                .HasColumnType("datetime")
                .HasColumnName("atualizacaodata");
            entity.Property(e => e.Criacaodata)
                .HasColumnType("datetime")
                .HasColumnName("criacaodata");
            entity.Property(e => e.Nomecategoria)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nomecategoria");
        });

        modelBuilder.Entity<Categorianota>(entity =>
        {
            entity.HasKey(e => e.Idnotacategoria).HasName("PK__categori__DBEBC2B2F265ADE8");

            entity.ToTable("categorianotas", tb => tb.HasTrigger("trg_audit_catnota"));

            entity.Property(e => e.Idnotacategoria).HasColumnName("idnotacategoria");
            entity.Property(e => e.Idcategoria).HasColumnName("idcategoria");
            entity.Property(e => e.Notaid).HasColumnName("notaid");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Categorianota)
                .HasForeignKey(d => d.Idcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__categoria__idcat__6C190EBB");

            entity.HasOne(d => d.Nota).WithMany(p => p.Categorianota)
                .HasForeignKey(d => d.Notaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__categoria__notai__6B24EA82");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.Idevento).HasName("PK__evento__C8A2BCFE67EE9CD1");

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
            entity.HasKey(e => e.Idnota).HasName("PK__notas__60059F491DD7711D");

            entity.ToTable("notas");

            entity.Property(e => e.Idnota).HasColumnName("idnota");
            entity.Property(e => e.Atualizacaonota)
                .HasColumnType("datetime")
                .HasColumnName("atualizacaonota");
            entity.Property(e => e.Datanota)
                .HasColumnType("datetime")
                .HasColumnName("datanota");
            entity.Property(e => e.Descricao)
                .HasColumnType("text")
                .HasColumnName("descricao");
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Imagenote)
                .IsUnicode(false)
                .HasColumnName("imagenote");
            entity.Property(e => e.Statusnote).HasColumnName("statusnote");
            entity.Property(e => e.Titulonota)
                .HasColumnType("text")
                .HasColumnName("titulonota");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK__notas__iduser__60A75C0F");
        });

        modelBuilder.Entity<Sharing>(entity =>
        {
            entity.HasKey(e => e.Idsharing).HasName("PK__sharing__1FEC517D842D7489");

            entity.ToTable("sharing", tb => tb.HasTrigger("trg_audit_sharing"));

            entity.Property(e => e.Idsharing).HasColumnName("idsharing");
            entity.Property(e => e.Notaid).HasColumnName("notaid");
            entity.Property(e => e.Permissao)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("permissao");
            entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");

            entity.HasOne(d => d.Nota).WithMany(p => p.Sharings)
                .HasForeignKey(d => d.Notaid)
                .HasConstraintName("FK__sharing__notaid__6383C8BA");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK__usuario__2A50F1CEFC49E73D");

            entity.ToTable("usuario", tb => tb.HasTrigger("trg_audit_usuario"));

            entity.HasIndex(e => e.Email, "UQ__usuario__AB6E61640B21A809").IsUnique();

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
