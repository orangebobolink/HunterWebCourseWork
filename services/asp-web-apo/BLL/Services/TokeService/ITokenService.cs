using BLL.DTOs.UserDTOs;
using DAL.Entities;

namespace BLL.Services.TokeService
{
    public interface ITokenService
    {
        public Token CreateAccessToken(UserDTO user);
        public Token CreateRefreshToken(UserDTO user);
        public bool ValidateAccessToken(Token token);
        public bool ValidateRefreshToken(Token token);
        public bool SaveToken(Token refreshToken);
        public bool DeleteToken(Token refreshToken);
        public bool FindToken(Token refreshToken);
    }
}
