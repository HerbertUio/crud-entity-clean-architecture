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
    public class PlantaService : IPlantaService
    {
        private readonly IRepository<Planta> _plantaRepository;

        public PlantaService (IRepository<Planta> plantaRepository)
        {
            _plantaRepository = plantaRepository;
        }

        public async Task<IEnumerable<PlantaDto>> GetAllAsync()
        {
            var plantas = await _plantaRepository.GetAllAsync();
            var plantaDtos = new List<PlantaDto>();

            foreach (var planta in plantas)
            {
                plantaDtos.Add(new PlantaDto
                {
                    Id = planta.Id,
                    Nombre = planta.Nombre,
                    Tipo = planta.Tipo,
                    EsPerenne = planta.EsPerenne
                });
            }

            return plantaDtos;
        }

        public async Task<PlantaDto> GetByIdAsync(int id)
        {
            var planta = await _plantaRepository.GetByIdAsync(id);
            if (planta == null)
                return null;

            return new PlantaDto
            {
                Id = planta.Id,
                Nombre = planta.Nombre,
                Tipo = planta.Tipo,
                EsPerenne = planta.EsPerenne
            };
        }
        public async Task AddAsync(PlantaDto plantaDto)
        {
            var planta = new Planta
            {
                Nombre = plantaDto.Nombre,
                Tipo = plantaDto.Tipo,
                EsPerenne = plantaDto.EsPerenne
            };

            planta.Validar(); // Validar entidad antes de agregar

            await _plantaRepository.AddAsync(planta);
        }

        public async Task UpdateAsync(PlantaDto plantaDto)
        {
            var planta = new Planta
            {
                Id = plantaDto.Id,
                Nombre = plantaDto.Nombre,
                Tipo = plantaDto.Tipo,
                EsPerenne = plantaDto.EsPerenne
            };

            planta.Validar();

            await _plantaRepository.UpdateAsync(planta);
        }
        public async Task DeleteAsync(int id)
        {
            await _plantaRepository.DeleteAsync(id);
        }
    }
}
