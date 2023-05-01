using BLL.DTOs.TokenDTOs;
using BLL.DTOs.UserDTOs;
using DAL.Entities;

namespace BLL.Services.TokeService
{
    public interface ITokenService
    {
        public string CreateAccessToken(UserDTO user);
        public RefreshTokenDTO CreateRefreshToken();
        public bool ValidateAccessToken(Token token);
        public Task<bool> ValidateRefreshToken(string refreshToken);
        public Task<bool> SaveToken(RefreshTokenDTO refreshToken);
        public Task<bool> DeleteToken(RefreshTokenDTO refreshToken);
        public Task<RefreshTokenDTO> FindToken(string token);
    }
}
