using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using DAL.Entities.HuntingSeasonEntities;
using DAL.Repositories.TypeRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.TypeServices
{
    internal class TypeService : ITypeService
    {
        private ITypeRepository _typeRepository;
        private IMapper _mapper;
        private ILogger<TypeService> _logger;

        public TypeService(ITypeRepository typeRepository, IMapper mapper, ILogger<TypeService> logger)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TypeOfHuntingDTO> AddAsync(TypeOfHuntingDTO item)
        {
            var typeChecked = await _typeRepository.GetByNameAsync(item.Name);

            if(typeChecked is not null)
            {
                _logger.LogError("Can't add gender: {name} already exists", typeChecked.Name);

                throw new NotFoundException("This name is already used");
            }

            var mapperModel = _mapper.Map<TypeOfHunting>(item);

            _typeRepository.Add(mapperModel);
            await _typeRepository.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<TypeOfHuntingDTO>> GetAllAsync()
        {
            var types = await _typeRepository.GetAllAsync();

            if(types is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<IEnumerable<TypeOfHuntingDTO>>(types);

            return mapperModel;
        }

        public async Task<TypeOfHuntingDTO?> GetByIdAsync(int id)
        {
            var typeChecked = await _typeRepository.GetByIdAsync(id);

            if(typeChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<TypeOfHuntingDTO>(typeChecked);

            return mapperModel;
        }

        public async Task<TypeOfHuntingDTO> GetByNameAsync(string name)
        {
            var typeChecked = await _typeRepository.GetByNameAsync(name);

            if(typeChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<TypeOfHuntingDTO>(typeChecked);

            return mapperModel;
        }

        public async Task<TypeOfHuntingDTO> RemoveAsync(TypeOfHuntingDTO item)
        {
            var typeChecked = await _typeRepository.GetByIdAsync(item.Id);

            if(typeChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _typeRepository.Remove(typeChecked);

            return item;
        }

        public async Task<TypeOfHuntingDTO> UpdateAsync(TypeOfHuntingDTO item)
        {
            var typeChecked = await _typeRepository.GetByIdAsync(item.Id);

            if(typeChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _typeRepository.Update(typeChecked);

            return item;
        }
    }
}
