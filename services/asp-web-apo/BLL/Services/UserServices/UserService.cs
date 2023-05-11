using AutoMapper;
using BLL.DTOs.UserDTOs;
using BLL.Exceptions;
using DAL.Entities.UserEntities;
using DAL.Repositories.FeedbackRepository;
using DAL.Repositories.UserRepository;
using Microsoft.Extensions.Logging;

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
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDetailDTO> AddAsync(UserDetailDTO item)
        {
            var userChecked = await _userRepository.GetByEmailAsync(item.Email);

            if(userChecked is not null)
            {
                _logger.LogError("");

                throw new NotFoundException("");
            }

            var mapperModel = _mapper.Map<User>(item);

            _userRepository.Add(mapperModel);
            await _userRepository.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<UserDetailDTO>> GetAllAsync()
        {
            var userChecked = await _userRepository.GetAllIncludeDetailAsync();

            if(userChecked is null)
            {
                _logger.LogError("");
                throw new NotFoundException("");
            }

            var mapperModel = _mapper.Map<IEnumerable<UserDetailDTO>>(userChecked);

            return mapperModel;
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

        public async Task<UserDetailDTO> GetByEmailIncludeDetailsAsync(string email)
        {
            var userChecked = await _userRepository.GetByEmailAsync(email);

            if(userChecked is null)
            {
                _logger.LogError("");
                throw new NotFoundException("");
            }

            var mapperModel = _mapper.Map<UserDetailDTO>(userChecked);

            return mapperModel;
        }

        public async Task<UserDetailDTO?> GetByIdAsync(int id)
        {
            var userChecked = await _userRepository.GetByIdIncludeDetailAsync(id);

            if(userChecked is null)
            {
                _logger.LogError("");
                throw new NotFoundException("");
            }

            var mapperModel = _mapper.Map<UserDetailDTO>(userChecked);

            return mapperModel;
        }

        public Task<UserDetailDTO> RemoveAsync(UserDetailDTO item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDetailDTO> UpdateAsync(UserDetailDTO item)
        {
            var userChecked = await _userRepository.GetByEmailAsync(item.Email);

            if(userChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            userChecked.UserDetail!.Phone = item.Phone;
            userChecked.UserDetail!.FirstName = item.FirstName;
            userChecked.Roles = null;
            userChecked.UserDetail.Messanger = null;

            _userRepository.Update(userChecked);
            await _userRepository.SaveChangesAsync();

            return item;
        }
    }
}
