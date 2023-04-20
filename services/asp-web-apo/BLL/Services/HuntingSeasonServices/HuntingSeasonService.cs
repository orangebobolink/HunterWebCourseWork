using AutoMapper;
using BLL.DTOs.Animal;
using BLL.DTOs.HuntingSeason;
using BLL.Exceptions;
using DAL.Entities.HuntingSeasonEntities;
using DAL.Repositories.AnimalRepository;
using DAL.Repositories.HuntingSeasonRepository;
using DAL.Repositories.MessangerRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.HuntingSeasonServices
{
    internal class HuntingSeasonService : IHuntingSeasonService
    {
        private IHuntingSeasonRepository _huntingSeasonRepository;
        private IMapper _mapper;
        private ILogger<HuntingSeasonService> _logger;

        public HuntingSeasonService(IHuntingSeasonRepository huntingSeasonRepository, IMapper mapper, ILogger<HuntingSeasonService> logger)
        {
            _huntingSeasonRepository = huntingSeasonRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<HuntingSeasonDetailDTO> AddAsync(HuntingSeasonDetailDTO item)
        {
            var mapperModel = _mapper.Map<HuntingSeason>(item);

            _huntingSeasonRepository.Add(mapperModel);
            await _huntingSeasonRepository.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<HuntingSeasonDetailDTO>> GetAllAsync()
        {
            var huntingSeasonsChecked = await _huntingSeasonRepository.GetAllAsync();

            if(huntingSeasonsChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<IEnumerable<HuntingSeasonDetailDTO>>(huntingSeasonsChecked);

            return mapperModel;
        }

        public async Task<IEnumerable<HuntingSeasonDTO>> GetAllHuntingSeasonsAsync()
        {
            var huntingSeasonsChecked = await _huntingSeasonRepository.GetAllAsync();

            if(huntingSeasonsChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<IEnumerable<HuntingSeasonDTO>>(huntingSeasonsChecked);

            return mapperModel;
        }

        public async Task<HuntingSeasonDetailDTO?> GetByIdAsync(int id)
        {
            var huntingSeasonChecked = await _huntingSeasonRepository.GetByIdAsync(id);

            if(huntingSeasonChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<HuntingSeasonDetailDTO>(huntingSeasonChecked);

            return mapperModel;
        }

        public async Task<HuntingSeasonDetailDTO> RemoveAsync(HuntingSeasonDetailDTO item)
        {
            var huntingSeasonChecked = await _huntingSeasonRepository.GetByIdAsync(item.Id);

            if(huntingSeasonChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _huntingSeasonRepository.Remove(huntingSeasonChecked);

            return item;
        }

        public async Task<HuntingSeasonDetailDTO> UpdateAsync(HuntingSeasonDetailDTO item)
        {
            var huntingSeasonChecked = await _huntingSeasonRepository.GetByIdAsync(item.Id);

            if(huntingSeasonChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _huntingSeasonRepository.Update(huntingSeasonChecked);

            return item;
        }
    }
}
