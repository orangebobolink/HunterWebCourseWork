using BLL.DTOs.UserDTOs;

namespace BLL.Services.UserServices
{
    public interface IUserService
    {
        public Task<UserDTO> GetByEmailAsync(string email);
    }
}
