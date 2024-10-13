using Frutas.Models;
using Frutas.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frutas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FruitController : ControllerBase
    {
        private readonly FruitService _fruitService;

        public FruitController(FruitService fruitService)
        {
            _fruitService = fruitService;
        }

        // GET: api/fruit
        [HttpGet]
        public async Task<IActionResult> GetAllFruits()
        {
            var fruits = await _fruitService.GetAllFruitsAsync();
            return Ok(fruits);
        }

        // GET: api/fruit/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFruitById(int id)
        {
            var fruit = await _fruitService.GetFruitByIdAsync(id);
            if (fruit == null)
            {
                return NotFound();
            }
            return Ok(fruit);
        }

        // POST: api/fruit
        [HttpPost]
        public async Task<IActionResult> CreateFruit(Fruit fruit)
        {
            var createdFruit = await _fruitService.CreateFruitAsync(fruit);
            return CreatedAtAction(nameof(GetFruitById), new { id = createdFruit.Id }, createdFruit);
        }

        // PUT: api/fruit/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFruit(int id, Fruit fruit)
        {
            var updatedFruit = await _fruitService.UpdateFruitAsync(id, fruit);
            if (updatedFruit == null)
            {
                return NotFound();
            }
            return Ok(updatedFruit);
        }

        // DELETE: api/fruit/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFruit(int id)
        {
            var deleted = await _fruitService.DeleteFruitAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
