using BLL.DTOs;
using BLL.DTOs.Animal;
using BLL.Services.HuntingSeasonServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuntingSeasonController : ControllerBase
    {
        private readonly IHuntingSeasonService _huntingSeasonService;

        public HuntingSeasonController(IHuntingSeasonService huntingSeasonService)
        {
            _huntingSeasonService = huntingSeasonService;
        }

        [HttpDelete]
        public async Task<ActionResult<HuntingSeasonDTO>> Delete(int id)
        {
            var season = await _huntingSeasonService.RemoveAsync(new HuntingSeasonDTO { Id = id });

            return Ok(season);
        }

        [HttpPut]
        public async Task<ActionResult<HuntingSeasonDTO>> Update(HuntingSeasonDTO huntingSeason)
        {
            var season = await _huntingSeasonService.UpdateAsync(huntingSeason);

            return Ok(season);
        }

        [HttpPost]
        public async Task<ActionResult<HuntingSeasonDTO>> Create(HuntingSeasonDTO huntingSeason)
        {
            var season = await _huntingSeasonService.AddAsync(huntingSeason);

            return Ok(season);
        }
    }
}
