using BLL.DTOs;
using BLL.Services.RoleServices;
using Microsoft.AspNetCore.Mvc;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAll()
        {
            var response = await _roleService.GetAll();

            return Ok(response);
        }
    }
}
