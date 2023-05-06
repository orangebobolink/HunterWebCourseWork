using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using DAL.Entities.HuntingSeasonEntities;
using DAL.Repositories.HuntingSeasonRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.HuntingSeasonServices
{
    internal class HuntingSeasonService : IHuntingSeasonService
    {
        // TODO: тут сделать чтобы можно вернуть по animal i
        private IHuntingSeasonRepository _huntingSeasonRepository;
        private IMapper _mapper;
        private ILogger<HuntingSeasonService> _logger;

        public HuntingSeasonService(IHuntingSeasonRepository huntingSeasonRepository, IMapper mapper, ILogger<HuntingSeasonService> logger)
        {
            _huntingSeasonRepository = huntingSeasonRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<HuntingSeasonDTO> AddAsync(HuntingSeasonDTO item)
        {
            var mapperModel = _mapper.Map<HuntingSeason>(item);

            _huntingSeasonRepository.Add(mapperModel);
            await _huntingSeasonRepository.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<HuntingSeasonDTO>> GetAllAsync()
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

        public async Task<HuntingSeasonDTO?> GetByIdAsync(int id)
        {
            var huntingSeasonChecked = await _huntingSeasonRepository.GetByIdAsync(id);

            if(huntingSeasonChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<HuntingSeasonDTO>(huntingSeasonChecked);

            return mapperModel;
        }

        public async Task<HuntingSeasonDTO> RemoveAsync(HuntingSeasonDTO item)
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

        public async Task<HuntingSeasonDTO> UpdateAsync(HuntingSeasonDTO item)
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
