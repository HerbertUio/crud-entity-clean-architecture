using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/celular")]
    public class CelularController : ControllerBase
    {
        private readonly IRepository<Celular> _repository;

        public CelularController(IRepository<Celular> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var celulares = await _repository.GetAllAsync();
            return Ok(celulares);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var celular = await _repository.GetByIdAsync(id);
            if (celular == null) return NotFound();
            return Ok(celular);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Celular celular)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _repository.AddAsync(celular);
            return CreatedAtAction(nameof(GetById), new { id = celular.Id }, celular);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Celular celular)
        {
            if (id != celular.Id) return BadRequest("El ID no coincide.");

            await _repository.UpdateAsync(celular);
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
