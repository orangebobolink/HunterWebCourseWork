using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.GenderServices;
using DAL.Entities;
using DAL.Repositories.MessangerRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.MessangerServices
{
    internal class MessangerService : IMessangerService
    {
        private IMessangerRepository _messangerRepository;
        private IMapper _mapper;
        private ILogger<GenderService> _logger;

        public MessangerService(IMessangerRepository messangerRepository, IMapper mapper, ILogger<GenderService> logger)
        {
            _messangerRepository = messangerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MessangerDTO> AddAsync(MessangerDTO item)
        {
            var messangerChecked = await _messangerRepository.GetByNameAsync(item.Name);

            if(messangerChecked is not null)
            {
                _logger.LogError("Can't add Messanger: {name} already exists", messangerChecked.Name);

                throw new NotFoundException("This name is already used");
            }

            var mapperModel = _mapper.Map<Messanger>(item);

            _messangerRepository.Add(mapperModel);
            await _messangerRepository.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<MessangerDTO>> GetAllAsync()
        {
            var genders = await _messangerRepository.GetAllAsync();

            if(genders is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<IEnumerable<MessangerDTO>>(genders);

            return mapperModel;
        }

        public async Task<MessangerDTO?> GetByIdAsync(int id)
        {
            var messangerChecked = await _messangerRepository.GetByIdAsync(id);

            if(messangerChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<MessangerDTO>(messangerChecked);

            return mapperModel;
        }

        public async Task<MessangerDTO> RemoveAsync(MessangerDTO item)
        {
            var messangerChecked = await _messangerRepository.GetByIdAsync(item.Id);

            if(messangerChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _messangerRepository.Remove(messangerChecked);

            return item;
        }

        public async Task<MessangerDTO> UpdateAsync(MessangerDTO item)
        {
            var messangerChecked = await _messangerRepository.GetByIdAsync(item.Id);

            if(messangerChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _messangerRepository.Update(messangerChecked);

            return item;
        }
    }
}
