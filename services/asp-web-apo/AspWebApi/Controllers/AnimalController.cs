using BLL.DTOs.Animal;
using BLL.Services.AnimalServices;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet("get")]
        public async Task<ActionResult<List<AnimalDTO>>> GetAllAnimalAsync()
        {
            var animals = await _animalService.GetAllAsync();

            return Ok(animals);
        }
    }
}
