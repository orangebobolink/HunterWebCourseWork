using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using DAL.Entities.HuntingSeasonEntities;
using DAL.Repositories.GenderRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.GenderServices
{
    // TODO: Logger
    internal class GenderService : IGenderService
    {
        private IGenderRepository _genderRepository;
        private IMapper _mapper;
        private ILogger<GenderService> _logger;

        public GenderService(IGenderRepository genderRepository, IMapper mapper, ILogger<GenderService> logger)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GenderDTO> AddAsync(GenderDTO item)
        {
            var genderChecked = await _genderRepository.GetByNameAsync(item.Name);

            if(genderChecked is not null)
            {
                _logger.LogError("Can't add gender: {name} already exists", genderChecked.Name);

                throw new NotFoundException("This name is already used");
            }

            var mapperModel = _mapper.Map<Gender>(item);

            _genderRepository.Add(mapperModel);
            await _genderRepository.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<GenderDTO>> GetAllAsync()
        {
            var genders = await _genderRepository.GetAllAsync();

            if(genders is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<IEnumerable<GenderDTO>>(genders);

            return mapperModel;
        }

        public async Task<GenderDTO?> GetByIdAsync(int id)
        {
            var genderChecked = await _genderRepository.GetByIdAsync(id);

            if(genderChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<GenderDTO>(genderChecked);

            return mapperModel;
        }

        public Task<GenderDTO> GetByNameAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<GenderDTO> RemoveAsync(GenderDTO item)
        {
            var genderChecked = await _genderRepository.GetByIdAsync(item.Id);

            if(genderChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _genderRepository.Remove(genderChecked);

            return item;
        }

        public async Task<GenderDTO> UpdateAsync(GenderDTO item)
        {
            var genderChecked = await _genderRepository.GetByIdAsync(item.Id);

            if(genderChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _genderRepository.Update(genderChecked);

            return item;
        }
    }
}
