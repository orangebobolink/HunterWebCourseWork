using BLL.DTOs.TokenDTOs;
using BLL.DTOs.UserDTOs;
using DAL.Entities;

namespace BLL.Services.TokeService
{
    public interface ITokenService
    {
        public string CreateAccessToken(UserDTO user);
        public RefreshTokenDTO CreateRefreshToken(string email);
        public bool ValidateAccessToken(Token token);
        public Task<bool> ValidateRefreshToken(string refreshToken);
        public Task<RefreshTokenDTO> AddAsync(RefreshTokenDTO refreshToken);
        public Task<RefreshTokenDTO> RemoveAsync(RefreshTokenDTO refreshToken);
        public Task<RefreshTokenDTO> FindToken(string token);
        public Task<RefreshTokenDTO> FindTokeByUserId(int id);
    }
}
