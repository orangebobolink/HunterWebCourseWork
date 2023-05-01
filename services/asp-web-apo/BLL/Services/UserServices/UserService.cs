using AutoMapper;
using BLL.DTOs.UserDTOs;
using BLL.Exceptions;
using BLL.Services.TokeService;
using DAL.Entities.UserEntities;
using DAL.Repositories.UserRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace BLL.Services.UserServices
{
    internal class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private ITokenService _tokenService;
        private IMapper _mapper;
        private ILogger<UserService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, ITokenService tokenService, IMapper mapper, ILogger<UserService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
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
            var validate = await _tokenService.ValidateRefreshToken(refreshToken);

            if(!validate)
                throw new Exceptions.UnauthorizedAccessException("Unautorized");

            var userEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)!.Value;
            var user = await GetByEmailAsync(userEmail);

            var newRefreshToken = _tokenService.CreateRefreshToken();
            var token = _tokenService.CreateAccessToken(user);

            var mapperModel = _mapper.Map<ResponseUserDto>(user);
            mapperModel.RefreshToken = newRefreshToken.RefreshToken;
            mapperModel.Created = newRefreshToken.Created;
            mapperModel.Expires = newRefreshToken.Expires;
            mapperModel.AccessToken = token;

            return mapperModel;
        }
    }
}
