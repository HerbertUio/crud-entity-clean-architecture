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
    public class CelularRepository : IRepository<Celular>
    {
        private readonly ApplicationDbContext _context;
        public CelularRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Celular>> GetAllAsync()
        {
            return await _context.Celulares.ToListAsync();
        }
        public async Task<Celular> GetByIdAsync(int id)
        {
            return await _context.Celulares.FindAsync(id);
        }
        public async Task AddAsync(Celular entity)
        {
            await _context.Celulares.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Celular entity)
        {
            _context.Celulares.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var celular = await _context.Celulares.FindAsync(id);
            if (celular != null)
            {
                _context.Celulares.Remove(celular);
                await _context.SaveChangesAsync();
            }
        }
    }
}
