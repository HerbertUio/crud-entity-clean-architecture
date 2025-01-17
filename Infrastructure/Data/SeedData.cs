using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

            // Si ya hay datos, no hacer nada
            if (context.Automoviles.Any()) return;

            // Crear algunos datos iniciales
            context.Automoviles.AddRange(
                new Automovil { Marca = "Toyota", Modelo = "Corolla", Año = 2020 },
                new Automovil { Marca = "Ford", Modelo = "Focus", Año = 2018 }
            );

            

            context.SaveChanges();
        }
    }
}
