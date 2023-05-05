using BLL.DTOs.TokenDTOs;
using BLL.DTOs.UserDTOs;

namespace BLL.Services.AuthServices
{
    public interface IAuthService
    {
        public Task<ResponseUserDto> Register(RequestUserDTO requestUserDTO);
        public Task<ResponseUserDto> Login(RequestUserDTO requestUserDTO);
        public Task<ResponseUserDto> Refresh(string refreshToken);
        public Task<RefreshTokenDTO> Logout(string refreshToken);
    }
}
