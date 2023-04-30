using BLL.DTOs.UserDTOs;
using DAL.Entities;

namespace BLL.Services.UserServices
{
    internal class UserService : IUserService
    {
        public UserDTO Login(RequestUserDTO user)
        {
            throw new NotImplementedException();
        }

        public UserDTO Logout(Token refreshToken)
        {
            throw new NotImplementedException();
        }

        public UserDTO Refresh(Token refreshToken)
        {
            throw new NotImplementedException();
        }

        public UserDTO Registration(RequestUserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
