using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICelularService
    {
        Task<IEnumerable<CelularDto>> GetAllAsync();
        Task<CelularDto> GetByIdAsync(int id);
        Task AddAsync(CelularDto celularDto);
        Task UpdateAsync(CelularDto celularDto);
        Task DeleteAsync(int id);
    }
}
