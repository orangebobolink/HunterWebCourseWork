using BLL.DTOs.Animal;
using BLL.DTOs.UserDTOs;
using BLL.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDetailDTO>>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("/email")]
        public async Task<ActionResult<UserDetailDTO>> GetByEmail(string email)
        {
            var users = await _userService.GetByEmailIncludeDetailsAsync(email);

            return Ok(users);
        }
    }
}
