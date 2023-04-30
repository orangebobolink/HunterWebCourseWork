using BLL.DTOs.UserDTOs;
using DAL.Entities;

namespace BLL.Services.UserServices
{
    public interface IUserService
    {
        public UserDTO Registration(RequestUserDTO user);
        public UserDTO Login(RequestUserDTO user);
        public UserDTO Logout(Token refreshToken);
        public UserDTO Refresh(Token refreshToken);
    }
}
