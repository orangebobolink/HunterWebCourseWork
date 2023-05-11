using AutoMapper;
using BLL.DTOs.TokenDTOs;
using BLL.DTOs.UserDTOs;
using BLL.Exceptions;
using BLL.Services.TokeService;
using DAL.Entities.UserEntities;
using DAL.Repositories.RoleRepository;
using DAL.Repositories.UserRepository;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DAL.Repositories.MessangerRepository;

namespace BLL.Services.AuthServices
{
    internal class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private ILogger<AuthService> _logger;
        private ITokenService _tokenService;
        private IRoleRepository _roleRepository;
        private IMessangerRepository _messangerRepository;

        public AuthService(IUserRepository userService,
            IRoleRepository roleRepository,
            IMapper mapper, ILogger<AuthService> logger,
            ITokenService tokenService,
            IMessangerRepository messangerRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userService;
            _mapper = mapper;
            _logger = logger;
            _tokenService = tokenService;
            _messangerRepository = messangerRepository;
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

        public async Task<ResponseUserDto> Register(RegisterUserDTO requestUserDTO)
        {
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
            var messanger = await _messangerRepository.GetByNameAsync(requestUserDTO.MessangerName);

            mapperModel.RoleUsers.Add(new RoleUser() { RoleId = defaultRole!.Id });
            mapperModel.UserDetail!.Messanger = null;
            mapperModel.UserDetail.MessangerId = messanger!.Id;

            _userRepository.Add(mapperModel);
            await _userRepository.SaveChangesAsync();

            var user = new ResponseUserDto()
            {
                Email = requestUserDTO.Email,
                Roles = new List<string>() { defaultRole!.Name }
            };

            return user;
        }

        public async Task<RefreshTokenDTO> Logout(string refreshToken)
        {
            var token = await _tokenService.RemoveAsync(new RefreshTokenDTO
            {
                RefreshToken = refreshToken
            });

            return token;
        }

        public async Task<ResponseUserDto> Refresh(string refreshToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(refreshToken);

            var userEmail = token.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var user = await _userRepository.GetByEmailAsync(userEmail);

            if(user is null)
            {
                throw new NotFoundException(userEmail);
            }

            await _tokenService.RemoveAsync(new RefreshTokenDTO
            {
                RefreshToken = refreshToken,
                UserId = user.Id
            });

            var newRefreshToken = _tokenService.CreateRefreshToken(userEmail);
            newRefreshToken.UserId = user.Id;

            await _tokenService.AddAsync(newRefreshToken);

            var userDto = _mapper.Map<UserDTO>(user);

            var accessToken = _tokenService.CreateAccessToken(userDto);

            var mapperModel = _mapper.Map<ResponseUserDto>(user);

            mapperModel.RefreshToken = newRefreshToken.RefreshToken;
            mapperModel.Created = newRefreshToken.Created;
            mapperModel.Expires = newRefreshToken.Expires;
            mapperModel.AccessToken = accessToken;

            return mapperModel;
        }

        public async Task<bool> CheckToken(string refreshToken)
        {

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(refreshToken);

            var userEmail = token.Claims.First(c => c.Type == ClaimTypes.Email).Value;

            var user = await _userRepository.GetByEmailAsync(userEmail);

            var tokenValid = await _tokenService.FindTokeByUserId(user!.Id);

            if(tokenValid.RefreshToken == string.Empty)
            {
                throw new Exception();
            }

            var validate = await _tokenService.ValidateRefreshToken(refreshToken);

            return validate;
        }
    }
}