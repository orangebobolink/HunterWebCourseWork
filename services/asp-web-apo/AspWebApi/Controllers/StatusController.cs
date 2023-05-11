using BLL.DTOs;
using BLL.Services.StatusServices;
using Microsoft.AspNetCore.Mvc;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> GetAll()
        {
            var response = await _statusService.GetAll();

            return Ok(response);
        }
    }
}
