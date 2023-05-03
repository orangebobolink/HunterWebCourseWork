using BLL.DTOs.UserDTOs;
using DAL.Entities;

namespace BLL.Services.UserServices
{
    public interface IUserService
    {
        public Task<UserDTO> GetByEmailAsync(string email);
        public Task<ResponseUserDto> Refresh(string refreshToken);
    }
}
