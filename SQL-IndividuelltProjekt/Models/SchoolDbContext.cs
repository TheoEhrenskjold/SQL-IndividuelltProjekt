using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SQL_IndividuelltProjekt.Models;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Betyg> Betygs { get; set; }

    public virtual DbSet<Klass> Klasses { get; set; }

    public virtual DbSet<Kur> Kurs { get; set; }

    public virtual DbSet<Lärare> Lärares { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-SIK0JHG;Initial Catalog=Labb2;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Betyg>(entity =>
        {
            entity.HasKey(e => e.BetygsId).HasName("PK__Betyg__2DD1328FE537F38F");

            entity.ToTable("Betyg");

            entity.Property(e => e.BetygsId)
                .ValueGeneratedNever()
                .HasColumnName("BetygsID");
            entity.Property(e => e.Betyg1)
                .ValueGeneratedOnAdd()
                .HasColumnName("Betyg");
            entity.Property(e => e.KursId).HasColumnName("KursID");
            entity.Property(e => e.LärarId).HasColumnName("LärarID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Kurs).WithMany(p => p.Betygs)
                .HasForeignKey(d => d.KursId)
                .HasConstraintName("FK__Betyg__KursID__4316F928");

            entity.HasOne(d => d.Lärar).WithMany(p => p.Betygs)
                .HasForeignKey(d => d.LärarId)
                .HasConstraintName("FK__Betyg__LärarID__440B1D61");
        });

        modelBuilder.Entity<Klass>(entity =>
        {
            entity.ToTable("Klass");

            entity.Property(e => e.KlassId).HasColumnName("KlassID");
            entity.Property(e => e.Klassnamn)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kur>(entity =>
        {
            entity.HasKey(e => e.KursId).HasName("PK__Kurs__BCCFFF3BC51CDED4");

            entity.Property(e => e.KursId)
                .ValueGeneratedNever()
                .HasColumnName("KursID");
            entity.Property(e => e.Kursnamn)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Lärare>(entity =>
        {
            entity.HasKey(e => e.LärarId).HasName("PK__Lärare__AD685B6C680731F4");

            entity.ToTable("Lärare");

            entity.Property(e => e.LärarId)
                .ValueGeneratedOnAdd()
                .HasColumnName("LärarID");
            entity.Property(e => e.Namn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ämne)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Lärar).WithOne(p => p.Lärare)
                .HasForeignKey<Lärare>(d => d.LärarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lärare_Personal");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.PersonalId).HasName("PK__Personal__28343713A8A7E4E1");

            entity.ToTable("Personal");

            entity.Property(e => e.PersonalId).HasColumnName("PersonalID");
            entity.Property(e => e.Befattning)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Namn)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A7951FD00C9");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.KlassId).HasColumnName("KlassID");
            entity.Property(e => e.Namn)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
