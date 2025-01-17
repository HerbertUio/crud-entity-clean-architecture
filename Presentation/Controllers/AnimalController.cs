using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/animal")]
    public class AnimalController : ControllerBase
    {
        private readonly IRepository<Animal> _repository;

        public AnimalController(IRepository<Animal> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var animales = await _repository.GetAllAsync();
            return Ok(animales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var animal = await _repository.GetByIdAsync(id);
            if (animal == null) return NotFound();
            return Ok(animal);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Animal animal)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _repository.AddAsync(animal);
            return CreatedAtAction(nameof(GetById), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Animal animal)
        {
            if (id != animal.Id) return BadRequest("El ID no coincide.");

            await _repository.UpdateAsync(animal);
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
