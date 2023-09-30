using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace elecciones_api.Models;

public partial class Cc101020Mm102120Context : DbContext
{
    public Cc101020Mm102120Context()
    {
    }

    public Cc101020Mm102120Context(DbContextOptions<Cc101020Mm102120Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Elecciones2019> Elecciones2019s { get; set; }

    


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("server=CC5-17\\SQLEXPRESS; database=CC101020__MM102120; integrated security = true;TrustServerCertificate=True;");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Elecciones2019>(entity =>
        {
            entity.ToTable("elecciones_2019");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Candidato)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("candidato");
            entity.Property(e => e.Departamento)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("departamento");
            entity.Property(e => e.Votos).HasColumnName("votos");
        });

        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
