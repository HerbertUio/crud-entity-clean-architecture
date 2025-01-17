using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAutomovilService
    {
        Task<IEnumerable<AutomovilDto>> GetAllAsync();
        Task<AutomovilDto> GetByIdAsync(int id);
        Task AddAsync(AutomovilDto automovilDto);
        Task UpdateAsync(AutomovilDto automovilDto);
        Task DeleteAsync(int id);
    }
}
