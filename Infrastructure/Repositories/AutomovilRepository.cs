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
    public class AutomovilRepository : IRepository<Automovil>
    {
        private readonly ApplicationDbContext _context;
        public AutomovilRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Automovil>> GetAllAsync()
        {
            return await _context.Automoviles.ToListAsync();
        }

        public async Task<Automovil> GetByIdAsync(int id)
        {
            return await _context.Automoviles.FindAsync(id);
        }

        public async Task AddAsync(Automovil entity)
        {
            await _context.Automoviles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Automovil entity)
        {
            _context.Automoviles.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var automovil = await _context.Automoviles.FindAsync(id);
            if (automovil != null)
            {
                _context.Automoviles.Remove(automovil);
                await _context.SaveChangesAsync();
            }
        }
    }
}
