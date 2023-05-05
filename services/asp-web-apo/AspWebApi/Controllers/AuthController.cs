using BLL.DTOs.TokenDTOs;
using BLL.DTOs.UserDTOs;
using BLL.Services.AuthServices;
using BLL.Services.TokeService;
using BLL.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IUserService _userService;
        private ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, ITokenService tokenService, IUserService userService, IConfiguration configuration)
        {
            _authService = authService;
            _userService = userService;
            _tokenService = tokenService;
            _configuration = configuration;
        }


        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            return Ok(userEmail);
        }

        [HttpPost("registration")]
        public async Task<ActionResult<ResponseUserDto>> Register(RequestUserDTO request)
        {
            var user = await _authService.Register(request);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseUserDto>> Login(RequestUserDTO request)
        {
            var userResponse = await _authService.Login(request);

            //var refreshToken = _tokenService.CreateRefreshToken();

            SetRefreshToken(new RefreshTokenDTO
            {
                RefreshToken = userResponse.RefreshToken,
                Created = userResponse.Created,
                Expires = userResponse.Expires
            });

            return Ok(userResponse);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var validate = await _tokenService.ValidateRefreshToken(refreshToken);

            if(!validate)
                Unauthorized();

            var user = await _userService.Refresh(refreshToken);

            SetRefreshToken(new RefreshTokenDTO()
            {
                RefreshToken = user.RefreshToken,
                Created = user.Created,
                Expires = user.Expires
            });

            return Ok(user);
        }

        [HttpPost("logout")]
        public async Task<ActionResult<string>> Logout()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var user = await _userService.Logout(refreshToken!);

            Response.Cookies.Delete("refreshToken");

            return Ok(refreshToken);
        }

        private void SetRefreshToken(RefreshTokenDTO refreshToken)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = refreshToken.Expires,
                SameSite = SameSiteMode.Lax
            };

            Response.Cookies.Append("refreshToken", refreshToken.RefreshToken, cookieOptions);
        }
    }
}
