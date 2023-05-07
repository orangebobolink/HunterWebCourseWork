using BLL.DTOs.TokenDTOs;
using BLL.DTOs.UserDTOs;

namespace BLL.Services.AuthServices
{
    public interface IAuthService
    {
        public Task<ResponseUserDto> Register(RegisterUserDTO requestUserDTO);
        public Task<ResponseUserDto> Login(RequestUserDTO requestUserDTO);
        public Task<ResponseUserDto> Refresh(string refreshToken);
        public Task<bool> CheckToken(string refreshToken);
        public Task<RefreshTokenDTO> Logout(string refreshToken);
    }
}
