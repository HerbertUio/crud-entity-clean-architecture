using Application.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository<Animal> _animalRepository;
        public AnimalService(IRepository<Animal> animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public async Task<IEnumerable<AnimalDto>> GetAllAsync()
        {
            var animales = await _animalRepository.GetAllAsync();
            var animalDtos = new List<AnimalDto>();
            foreach (var animal in animales)
            {
                animalDtos.Add(new AnimalDto
                {
                    Id = animal.Id,
                    Nombre = animal.Nombre,
                    Especie = animal.Especie,
                    Edad = animal.Edad
                });
            }
            return animalDtos;
        }

        public async Task<AnimalDto> GetByIdAsync(int id)
        {
            var animal = await _animalRepository.GetByIdAsync(id);
            if (animal == null)
                return null;
            return new AnimalDto
            {
                Id = animal.Id,
                Nombre = animal.Nombre,
                Especie = animal.Especie,
                Edad = animal.Edad
            };
        }

        public async Task AddAsync(AnimalDto animalDto)
        {
            var animal = new Animal
            {
                Nombre = animalDto.Nombre,
                Especie = animalDto.Especie,
                Edad = animalDto.Edad
            };
            await _animalRepository.AddAsync(animal);
        }

        public async Task UpdateAsync(AnimalDto animalDto)
        {
            var animal = await _animalRepository.GetByIdAsync(animalDto.Id);
            if (animal == null)
                throw new Exception("Animal no encontrado");
            animal.Nombre = animalDto.Nombre;
            animal.Especie = animalDto.Especie;
            animal.Edad = animalDto.Edad;
            await _animalRepository.UpdateAsync(animal);
        }

        public async Task DeleteAsync(int id)
        {
            var animal = await _animalRepository.GetByIdAsync(id);
            if (animal == null)
                throw new Exception("Animal no encontrado");
            await _animalRepository.DeleteAsync(id);
        }
    }
}
