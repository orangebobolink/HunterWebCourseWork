using AutoMapper;
using BLL.DTOs.TokenDTOs;
using BLL.DTOs.UserDTOs;
using BLL.Exceptions;
using BLL.Services.TokeService;
using DAL.Repositories.UserRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BLL.Services.UserServices
{
    internal class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private ITokenService _tokenService;
        private IMapper _mapper;
        private ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ITokenService tokenService, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDTO> GetByEmailAsync(string email)
        {
            var userChecked = await _userRepository.GetByEmailAsync(email);

            if(userChecked is null)
            {
                _logger.LogError("");
                throw new NotFoundException("");
            }

            var mapperModel = _mapper.Map<UserDTO>(userChecked);

            return mapperModel;
        }

        public async Task<ResponseUserDto> Refresh(string refreshToken)
        {
            await _tokenService.RemoveAsync(new RefreshTokenDTO { RefreshToken = refreshToken });

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(refreshToken);

            var userEmail = token.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var user = await GetByEmailAsync(userEmail);

            var newRefreshToken = _tokenService.CreateRefreshToken(userEmail);
            newRefreshToken.UserId = user.Id;

            await _tokenService.AddAsync(newRefreshToken);

            var accessToken = _tokenService.CreateAccessToken(user);

            var mapperModel = _mapper.Map<ResponseUserDto>(user);
            mapperModel.RefreshToken = newRefreshToken.RefreshToken;
            mapperModel.Created = newRefreshToken.Created;
            mapperModel.Expires = newRefreshToken.Expires;
            mapperModel.AccessToken = accessToken;

            return mapperModel;
        }
    }
}
