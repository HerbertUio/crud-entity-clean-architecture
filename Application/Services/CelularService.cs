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
    public class CelularService : ICelularService
    {
        private readonly IRepository<Celular> _celularRepository;
        public CelularService(IRepository<Celular> celularRepository)
        {
            _celularRepository = celularRepository;
        }
        public async Task<IEnumerable<CelularDto>> GetAllAsync()
        {
            var celulares = await _celularRepository.GetAllAsync();
            var celularDtos = new List<CelularDto>();
            foreach (var celular in celulares)
            {
                celularDtos.Add(new CelularDto
                {
                    Id = celular.Id,
                    Marca = celular.Marca,
                    Modelo = celular.Modelo,
                    Año = celular.Año
                });
            }
            return celularDtos;
        }
        public async Task<CelularDto> GetByIdAsync(int id)
        {
            var celular = await _celularRepository.GetByIdAsync(id);
            if (celular == null)
                return null;
            return new CelularDto
            {
                Id = celular.Id,
                Marca = celular.Marca,
                Modelo = celular.Modelo,
                Año = celular.Año
            };
        }

        public async Task AddAsync(CelularDto celularDto)
        {
            var celular = new Celular
            {
                Marca = celularDto.Marca,
                Modelo = celularDto.Modelo,
                Año = celularDto.Año
            };
            await _celularRepository.AddAsync(celular);
        }

        public async Task UpdateAsync(CelularDto celularDto)
        {
            var celular = await _celularRepository.GetByIdAsync(celularDto.Id);
            if (celular == null)
                throw new Exception("Celular no encontrado");
            celular.Marca = celularDto.Marca;
            celular.Modelo = celularDto.Modelo;
            celular.Año = celularDto.Año;
            await _celularRepository.UpdateAsync(celular);
        }
        public async Task DeleteAsync(int id)
        {
            await _celularRepository.DeleteAsync(id);
        }
    }
}
