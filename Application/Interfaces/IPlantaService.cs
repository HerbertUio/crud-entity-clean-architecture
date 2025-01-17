using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPlantaService
    {
        Task<IEnumerable<PlantaDto>> GetAllAsync();
        Task<PlantaDto> GetByIdAsync(int id);
        Task AddAsync(PlantaDto plantaDto);
        Task UpdateAsync(PlantaDto plantaDto);
        Task DeleteAsync(int id);
    }
}
