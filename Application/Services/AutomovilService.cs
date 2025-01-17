using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{

    public class AutomovilService : IAutomovilService
    {
        private readonly IRepository<Automovil> _automovilRepository;

        public AutomovilService(IRepository<Automovil> automovilRepository)
        {
            _automovilRepository = automovilRepository;
        }

        public async Task<IEnumerable<AutomovilDto>> GetAllAsync()
        {
            var automoviles = await _automovilRepository.GetAllAsync();
            var automovilDtos = new List<AutomovilDto>();

            foreach (var automovil in automoviles)
            {
                automovilDtos.Add(new AutomovilDto
                {
                    Id = automovil.Id,
                    Marca = automovil.Marca,
                    Modelo = automovil.Modelo,
                    Año = automovil.Año
                });
            }

            return automovilDtos;
        }

        public async Task<AutomovilDto> GetByIdAsync(int id)
        {
            var automovil = await _automovilRepository.GetByIdAsync(id);
            if (automovil == null)
                return null;

            return new AutomovilDto
            {
                Id = automovil.Id,
                Marca = automovil.Marca,
                Modelo = automovil.Modelo,
                Año = automovil.Año
            };
        }

        public async Task AddAsync(AutomovilDto automovilDto)
        {
            var automovil = new Automovil
            {
                Marca = automovilDto.Marca,
                Modelo = automovilDto.Modelo,
                Año = automovilDto.Año
            };

            automovil.Validar(); // Validar entidad antes de agregar

            await _automovilRepository.AddAsync(automovil);
        }

        public async Task UpdateAsync(AutomovilDto automovilDto)
        {
            var automovil = new Automovil
            {
                Id = automovilDto.Id,
                Marca = automovilDto.Marca,
                Modelo = automovilDto.Modelo,
                Año = automovilDto.Año
            };

            automovil.Validar();

            await _automovilRepository.UpdateAsync(automovil);
        }

        public async Task DeleteAsync(int id)
        {
            await _automovilRepository.DeleteAsync(id);
        }
    }
}
