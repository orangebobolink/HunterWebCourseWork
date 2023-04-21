using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using DAL.Entities.HuntingSeasonEntities;
using DAL.Repositories.MethodRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.MethodServices
{
    internal class MethodService : IMethodService
    {
        private IMethodRepository _methodRepository;
        private IMapper _mapper;
        private ILogger<MethodService> _logger;

        public MethodService(IMethodRepository methodRepository, IMapper mapper, ILogger<MethodService> logger)
        {
            _methodRepository = methodRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MethodOfHuntingDTO> AddAsync(MethodOfHuntingDTO item)
        {
            var methodChecked = await _methodRepository.GetByNameAsync(item.Name);

            if(methodChecked is not null)
            {
                _logger.LogError("Can't add gender: {name} already exists", methodChecked.Name);

                throw new NotFoundException("This name is already used");
            }

            var mapperModel = _mapper.Map<MethodOfHunting>(item);

            _methodRepository.Add(mapperModel);
            await _methodRepository.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<MethodOfHuntingDTO>> GetAllAsync()
        {
            var methods = await _methodRepository.GetAllAsync();

            if(methods is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<IEnumerable<MethodOfHuntingDTO>>(methods);

            return mapperModel;
        }

        public async Task<MethodOfHuntingDTO?> GetByIdAsync(int id)
        {
            var methodChecked = await _methodRepository.GetByIdAsync(id);

            if(methodChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<MethodOfHuntingDTO>(methodChecked);

            return mapperModel;
        }

        public async Task<MethodOfHuntingDTO> GetByNameAsync(string name)
        {
            var methodChecked = await _methodRepository.GetByNameAsync(name);

            if(methodChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<MethodOfHuntingDTO>(methodChecked);

            return mapperModel;
        }

        public async Task<MethodOfHuntingDTO> RemoveAsync(MethodOfHuntingDTO item)
        {
            var methodChecked = await _methodRepository.GetByIdAsync(item.Id);

            if(methodChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _methodRepository.Remove(methodChecked);

            return item;
        }

        public async Task<MethodOfHuntingDTO> UpdateAsync(MethodOfHuntingDTO item)
        {
            var methodChecked = await _methodRepository.GetByIdAsync(item.Id);

            if(methodChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _methodRepository.Update(methodChecked);

            return item;
        }
    }
}
