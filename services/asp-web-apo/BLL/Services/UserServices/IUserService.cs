using BLL.DTOs.UserDTOs;
using BLL.Interfaces;

namespace BLL.Services.UserServices
{
    public interface IUserService : IBaseService<UserDetailDTO>
    {
        public Task<UserDTO> GetByEmailAsync(string email);
        public Task<UserDetailDTO> GetByEmailIncludeDetailsAsync(string email);
    }
}
