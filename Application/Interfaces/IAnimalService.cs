using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAnimalService
    {
        Task<AnimalDto> GetByIdAsync(int id);
        Task<IEnumerable<AnimalDto>> GetAllAsync();
        Task AddAsync(AnimalDto animalDto);
        Task UpdateAsync(AnimalDto animalDto);
        Task DeleteAsync(int id);
    }
}
