using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/automovil")]
    public class AutomovilController : ControllerBase
    {
        private readonly IRepository<Automovil> _repository;

        public AutomovilController(IRepository<Automovil> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var automoviles = await _repository.GetAllAsync();
            return Ok(automoviles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var automovil = await _repository.GetByIdAsync(id);
            if (automovil == null) return NotFound();
            return Ok(automovil);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Automovil automovil)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _repository.AddAsync(automovil);
            return CreatedAtAction(nameof(GetById), new { id = automovil.Id }, automovil);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Automovil automovil)
        {
            if (id != automovil.Id) return BadRequest("El ID no coincide.");

            await _repository.UpdateAsync(automovil);
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
