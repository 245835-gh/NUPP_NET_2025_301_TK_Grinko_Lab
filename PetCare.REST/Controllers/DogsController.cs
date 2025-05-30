using Microsoft.AspNetCore.Mvc;
using PetCare.Infrastructure.Models;
using PetCare.REST.Models;
using PetCare.Common.Services;

namespace PetCare.REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogsController : ControllerBase
    {
        private readonly ICrudServiseAsync<DogModel> _dogService;

        public DogsController(ICrudServiseAsync<DogModel> dogService)
        {
            _dogService = dogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dogs = await _dogService.ReadAllAsync();
            var result = dogs.Select(d => new DogDto
            {
                Id = d.Id,
                Name = d.Name,
                Age = d.Age,
                Breed = d.Breed
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dog = await _dogService.ReadAsync(Guid.Empty);
            if (dog == null) return NotFound();
            return Ok(new DogDto { Id = dog.Id, Name = dog.Name, Age = dog.Age, Breed = dog.Breed });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DogDto dto)
        {
            var dog = new DogModel { Name = dto.Name, Age = dto.Age, Breed = dto.Breed };
            var created = await _dogService.CreateAsync(dog);
            if (!created) return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = dog.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DogDto dto)
        {
            var dog = new DogModel { Id = id, Name = dto.Name, Age = dto.Age, Breed = dto.Breed };
            var updated = await _dogService.UpdateAsync(dog);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dog = new DogModel { Id = id };
            var removed = await _dogService.RemoveAsync(dog);
            if (!removed) return NotFound();
            return NoContent();
        }
    }
}
