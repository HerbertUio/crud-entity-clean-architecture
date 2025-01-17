using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets para todas las entidades
        public DbSet<Automovil> Automoviles { get; set; }
        public DbSet<Animal> Animales { get; set; }
        public DbSet<Celular> Celulares { get; set; }
        public DbSet<Planta> Plantas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración adicional de las entidades (si es necesario)
            modelBuilder.Entity<Automovil>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Marca).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Modelo).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Año).IsRequired();
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Especie).IsRequired().HasMaxLength(100);
                entity.Property(a => a.Edad).IsRequired();
            });

            modelBuilder.Entity<Celular>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Marca).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Modelo).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Año).IsRequired();
            });

            modelBuilder.Entity<Planta>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Tipo).IsRequired().HasMaxLength(100);
                entity.Property(p => p.EsPerenne).IsRequired();
            });
        }
    }
}
