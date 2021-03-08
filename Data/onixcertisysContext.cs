using System;
using handleFileCertificados.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace handleFileCertificados.Data
{
    public partial class onixcertisysContext : DbContext
    {
        public onixcertisysContext()
        {
        }

        public onixcertisysContext(DbContextOptions<onixcertisysContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Asignacion> Asignacion { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Asignacion>(entity =>
            {
                entity.HasKey(e => e.Idruta)
                    .HasName("PRIMARY");

                entity.ToTable("asignacion");

                entity.Property(e => e.Idruta)
                    .HasColumnName("idruta")
                    .HasColumnType("int(10) unsigned");

                entity.Property(e => e.Rutaexcel)
                    .HasColumnName("rutaexcel")
                    .HasColumnType("varchar(250)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

        }
    }
}
