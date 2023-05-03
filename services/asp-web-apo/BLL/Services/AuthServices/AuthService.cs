using AutoMapper;
using Azure.Core;
using BLL.DTOs.UserDTOs;
using BLL.Exceptions;
using BLL.Services.TokeService;
using DAL.Entities;
using DAL.Entities.UserEntities;
using DAL.Repositories.RoleRepository;
using DAL.Repositories.UserRepository;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Services.AuthServices
{
    internal class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private ILogger<AuthService> _logger;
        private ITokenService _tokenService;
        private IRoleRepository _roleRepository; // TODO: поменять на сервер

        public AuthService(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper, ILogger<AuthService> logger, ITokenService tokenService)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
            _tokenService = tokenService;
        }

        public async Task<ResponseUserDto> Login(RequestUserDTO requestUserDTO)
        {
            var userChecked = await _userRepository.GetByEmailAsync(requestUserDTO.Email);

            if(userChecked is null)
            {
                _logger.LogError("This user is not register");

                throw new NotFoundException("This user is not register");
            }

            if(!VerifyPasswordHash(requestUserDTO.Password, userChecked.PasswordHash, userChecked.PasswordSalt))
            {
                _logger.LogError("Password is not valid");

                throw new NotFoundException("Password is not valid");
            }


            var refreshToken = _tokenService.CreateRefreshToken(userChecked.Email);

            refreshToken.UserId = userChecked.Id;

            var oldRefreshToken = await _tokenService.FindTokeByUserId(refreshToken.UserId);

            if(oldRefreshToken.RefreshToken != string.Empty)
                await _tokenService.RemoveAsync(oldRefreshToken);

            await _tokenService.AddAsync(refreshToken);

            var user = _mapper.Map<UserDTO>(userChecked);

            string token = _tokenService.CreateAccessToken(user);

            var userResponse = new ResponseUserDto()
            {
                Email = user.Email,
                Roles = user.Roles,
                AccessToken = token,
                RefreshToken = refreshToken.RefreshToken,
                Created = refreshToken.Created,
                Expires = refreshToken.Expires
            };

            return userResponse;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public async Task<ResponseUserDto> Register(RequestUserDTO requestUserDTO)
        {
            // TODO: добавит проверки для email и пароль
            var userChecked = await _userRepository.GetByEmailAsync(requestUserDTO.Email);

            if(userChecked is not null)
            {
                _logger.LogError("This user is already register");

                throw new NotFoundException("Already register");
            }

            var mapperModel = _mapper.Map<User>(requestUserDTO);

            CreatePasswordHash(requestUserDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

            mapperModel.PasswordSalt = passwordSalt;
            mapperModel.PasswordHash = passwordHash;

            var defaultRole = await _roleRepository.GetByNameAsync("user");

            mapperModel.RoleUsers.Add(new RoleUser() { RoleId = defaultRole!.Id });

            _userRepository.Add(mapperModel);
            await _userRepository.SaveChangesAsync();

            var user = new ResponseUserDto()
            {
                Email = requestUserDTO.Email,
                Roles = new List<string>() { defaultRole!.Name }
            };

            return user;
        }
    }
}