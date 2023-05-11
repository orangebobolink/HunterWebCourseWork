using BLL.DTOs;
using BLL.DTOs.Animal;
using BLL.Services.AnimalServices;
using BLL.Services.MessangerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessangerController : ControllerBase
    {
        private IMessangerService _messangerService;

        public MessangerController(IMessangerService messangerService)
        {
            _messangerService = messangerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetAll()
        {
            var messangers = await _messangerService.GetAllAsync();

            var list = messangers.Select(x => x.Name).ToList();

            if(messangers is null)
                return BadRequest(list);

            return Ok(list);
        }
    }
}
