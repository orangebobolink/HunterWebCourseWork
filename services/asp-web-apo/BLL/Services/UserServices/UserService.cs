using AutoMapper;
using BLL.DTOs.TokenDTOs;
using BLL.DTOs.UserDTOs;
using BLL.Exceptions;
using BLL.Services.TokeService;
using DAL.Repositories.UserRepository;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BLL.Services.UserServices
{
    internal class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
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
    }
}
