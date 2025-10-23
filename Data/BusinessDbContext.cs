using BusinessService.Models;
using Microsoft.EntityFrameworkCore;

namespace Skynet.BusinessService.Data
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext(DbContextOptions<BusinessDbContext> options)
            : base(options)
        {
        }

        // Solo entidades del dominio de negocio
        public DbSet<TipoCliente> TiposClientes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<VisitaTecnica> VisitasTecnicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TipoCliente
            modelBuilder.Entity<TipoCliente>()
                .ToTable("TipoCliente")
                .HasKey(t => t.Id);

            modelBuilder.Entity<TipoCliente>()
                .Property(t => t.Nombre)
                .HasMaxLength(50)
                .IsRequired();

            // Cliente
            modelBuilder.Entity<Cliente>()
                .ToTable("Clientes")
                .HasKey(c => c.Id);

          /*  modelBuilder.Entity<Cliente>()
                .HasOne(c => c.TipoCliente)
                .WithMany()
                .HasForeignKey(c => c.IdTipoCliente);*/

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.NIT)
                .IsUnique();

            // Puesto
            modelBuilder.Entity<Puesto>()
                .ToTable("Puesto")
                .HasKey(p => p.Id);

            // Empleado
            modelBuilder.Entity<Empleado>()
                .ToTable("Empleados")
                .HasKey(e => e.IdEmpleado);

            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Puesto)
                .WithMany()
                .HasForeignKey(e => e.IdPuesto);

            modelBuilder.Entity<Empleado>()
                .HasIndex(e => e.Codigo)
                .IsUnique();

            // VisitaTecnica
            modelBuilder.Entity<VisitaTecnica>()
                .ToTable("VisitaTecnica")
                .HasKey(v => v.IdVisita);

            modelBuilder.Entity<VisitaTecnica>()
                .HasOne(v => v.Cliente)
                .WithMany()
                .HasForeignKey(v => v.IdCliente);

            modelBuilder.Entity<VisitaTecnica>()
                .HasOne(v => v.Empleado)
                .WithMany()
                .HasForeignKey(v => v.IdEmpleado);
        }
    }
}
