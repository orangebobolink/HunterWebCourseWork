using BLL.DTOs.UserDTOs;

namespace BLL.Services.AuthServices
{
    public interface IAuthService
    {
        public Task<ResponseUserDto> Register(RequestUserDTO requestUserDTO);
        public Task<ResponseUserDto> Login(RequestUserDTO requestUserDTO);
    }
}
