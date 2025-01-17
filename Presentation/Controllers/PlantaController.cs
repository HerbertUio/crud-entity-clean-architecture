using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/planta")]
    public class PlantaController : ControllerBase
    {
        private readonly IRepository<Planta> _repository;

        public PlantaController(IRepository<Planta> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var plantas = await _repository.GetAllAsync();
            return Ok(plantas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var planta = await _repository.GetByIdAsync(id);
            if (planta == null) return NotFound();
            return Ok(planta);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Planta planta)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _repository.AddAsync(planta);
            return CreatedAtAction(nameof(GetById), new { id = planta.Id }, planta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Planta planta)
        {
            if (id != planta.Id) return BadRequest("El ID no coincide.");

            await _repository.UpdateAsync(planta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}