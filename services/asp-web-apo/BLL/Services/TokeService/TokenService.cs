using AutoMapper;
using BLL.DTOs.UserDTOs;
using DAL.Entities;
using DAL.Repositories.TokenRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public Token CreateAccessToken(UserDTO user)
        {
            var jwt = CreateToken(user);

            var token = new Token()
            {
                RefreshToken = jwt,
            };

            return token;
        }

        public Token CreateRefreshToken(UserDTO user)
        {
            var jwt = CreateToken(user);

            var token = new Token()
            {
                RefreshToken = jwt,
            };

            return token;
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
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public bool DeleteToken(Token refreshToken)
        {
            throw new NotImplementedException();
        }

        public bool FindToken(Token refreshToken)
        {
            throw new NotImplementedException();
        }

        public bool SaveToken(Token refreshToken)
        {
            throw new NotImplementedException();
        }

        public bool ValidateAccessToken(Token token)
        {
            throw new NotImplementedException();
        }

        public bool ValidateRefreshToken(Token token)
        {
            throw new NotImplementedException();
        }
    }
}
