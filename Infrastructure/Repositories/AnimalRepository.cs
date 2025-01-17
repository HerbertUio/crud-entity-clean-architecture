using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AnimalRepository : IRepository<Animal>
    {
        private readonly ApplicationDbContext _context;

        public AnimalRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _context.Animales.ToListAsync();
        }

        public async Task<Animal> GetByIdAsync(int id)
        {
            return await _context.Animales.FindAsync(id);
        }

        public async Task AddAsync(Animal entity)
        {
            await _context.Animales.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Animal entity)
        {
            _context.Animales.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var animal = await _context.Animales.FindAsync(id);
            if (animal != null)
            {
                _context.Animales.Remove(animal);
                await _context.SaveChangesAsync();
            }
        }
    }
}
