using BLL.DTOs.Animal;
using BLL.Services.AnimalServices;
using Microsoft.AspNetCore.Mvc;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<AnimalDTO>>> GetAllAnimalAsync()
        {
            var animals = await _animalService.GetAllAsync();

            if(animals is null)
                return BadRequest(animals);

            return Ok(animals);
        }

        [HttpGet("get/:id")]
        public async Task<ActionResult<List<AnimalDTO>>> GetAnimalById(int id)
        {
            var animal = await _animalService.GetByIdAsync(id);

            if(animal is null)
                return BadRequest(animal);

            return Ok(animal);
        }
    }
}
