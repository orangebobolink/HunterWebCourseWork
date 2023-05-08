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

        [HttpGet]
        public async Task<ActionResult<List<AnimalDTO>>> GetAllAnimalAsync()
        {
            var animals = await _animalService.GetAllAsync();

            if(animals is null)
                return BadRequest(animals);

            return Ok(animals);
        }

        [HttpGet("name")]
        public async Task<ActionResult<AnimalDetailDTO>> GetAnimalByName(string name)
        {
            var animal = await _animalService.GetByEnglishNameAsync(name);

            if(animal is null)
                return BadRequest(animal);

            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalDetailDTO>> CreateAnimal(string name, string description, string imageUrl)
        {
            var animalDto = new AnimalDetailDTO()
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl
            };

            var animal = await _animalService.AddAsync(animalDto);

            if(animal is null)
                return BadRequest(animal);

            return Ok(animal);
        }
    }
}
