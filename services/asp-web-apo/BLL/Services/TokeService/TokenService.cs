using AutoMapper;
using BLL.DTOs.TokenDTOs;
using BLL.DTOs.UserDTOs;
using BLL.Exceptions;
using DAL.Entities;
using DAL.Entities.UserEntities;
using DAL.Repositories.TokenRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Services.TokeService
{
    internal class TokenService : ITokenService
    {
        private ITokenRepository _tokenRepository;
        private IMapper _mapper;
        private ILogger<TokenService> _logger;
        private IConfiguration _configuration;

        public TokenService(ITokenRepository tokenRepository, IMapper mapper, ILogger<TokenService> logger, IConfiguration configuration)
        {
            _tokenRepository = tokenRepository;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
        }

        public string CreateAccessToken(UserDTO user)
        {
            var jwt = CreateToken(user);

            return jwt;
        }

        public RefreshTokenDTO CreateRefreshToken()
        {
            var refreshToken = new RefreshTokenDTO()
            {
                RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(30),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private string CreateToken(UserDTO user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "user")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                   _configuration.GetSection("JWT:Secret").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(10),
                    signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public Task<bool> DeleteToken(RefreshTokenDTO refreshToken)
        {
            throw new Exceptions.NotImplementedException("");
        }

        public async Task<RefreshTokenDTO> FindToken(string token)
        {
            var tokenChecked = await _tokenRepository.GetByTokenAsync(token);

            if(tokenChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("Token is not found");
            }

            var mapperModel = _mapper.Map<RefreshTokenDTO>(tokenChecked);

            return mapperModel;
        }

        public Task<bool> SaveToken(RefreshTokenDTO refreshToken)
        {
            throw new Exceptions.NotImplementedException("");
        }

        public bool ValidateAccessToken(Token token)
        {
            throw new Exceptions.NotImplementedException("");
        }

        public async Task<bool> ValidateRefreshToken(string refreshToken)
        {
            var token = await FindToken(refreshToken);

            if(!token.RefreshToken.Equals(refreshToken))
            {
                _logger.LogError("Unautorize");
                throw new Exceptions.UnauthorizedAccessException("Refresh token is not validation");
            }
            else if(token.Expires < DateTime.Now)
            {
                _logger.LogError("Unautorize");
                throw new Exceptions.UnauthorizedAccessException("Refresh token is not validation");
            }

            return true;
        }
    }
}
