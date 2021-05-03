using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LAFISE.Models
{
    public partial class Aplicacion : DbContext
    {
        public Aplicacion()
            : base("name=Conexion")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Transacciones> Transacciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
                .Property(e => e.IdCliente)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.NombreCliente)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Telefono)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Transacciones)
                .WithRequired(e => e.Clientes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.IdTransaccion)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.DescripcionTransa)
                .IsUnicode(false);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.MontoTransaccion)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.IdCliente)
                .HasPrecision(18, 0);
        }
    }
}
