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
    public class PlantaRepository: IRepository<Planta>
    {
        private readonly ApplicationDbContext _context;
        public PlantaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Planta>> GetAllAsync()
        {
            return await _context.Plantas.ToListAsync();
        }

        public async Task<Planta> GetByIdAsync(int id)
        {
            return await _context.Plantas.FindAsync(id);
        }

        public async Task AddAsync(Planta entity)
        {
            await _context.Plantas.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Planta entity)
        {
            _context.Plantas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var planta = await _context.Plantas.FindAsync(id);
            if (planta != null)
            {
                _context.Plantas.Remove(planta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
