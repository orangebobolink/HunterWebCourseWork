using AutoMapper;
using BLL.DTOs.Animal;
using BLL.Exceptions;
using DAL.Entities.AnimalEntities;
using DAL.Repositories.AnimalRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.AnimalServices
{
    internal class AnimalService : IAnimalService
    {
        private IAnimalRepository _animalRepository;
        private IMapper _mapper;
        private ILogger<AnimalService> _logger;

        public AnimalService(IAnimalRepository animalRepository, IMapper mapper, ILogger<AnimalService> logger)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AnimalDetailDTO> AddAsync(AnimalDetailDTO item)
        {
            // TODO: по getbyname методы, типы и тд подсоеденять 

            var animalChecked = _animalRepository.GetByNameAsync(item.Name);

            if(animalChecked is not null)
            {
                _logger.LogError("");

                throw new NotFoundException("This name is already used");
            }

            var mapperModel = _mapper.Map<Animal>(item);

            _animalRepository.Add(mapperModel);
            await _animalRepository.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<AnimalDTO>> GetAllAsync()
        {
            var animalsChecked = await _animalRepository.GetAllAsync();

            if(animalsChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<IEnumerable<AnimalDTO>>(animalsChecked);

            return mapperModel;
        }

        public async Task<AnimalDetailDTO?> GetByIdAsync(int id)
        {
            var animalChecked = await _animalRepository.GetByIdAsync(id);

            if(animalChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<AnimalDetailDTO>(animalChecked);

            return mapperModel;
        }

        public async Task<AnimalDetailDTO?> GetByNameAsync(string name)
        {
            var animalChecked = await _animalRepository.GetByNameAsync(name);

            if(animalChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<AnimalDetailDTO>(animalChecked);

            return mapperModel;
        }

        public async Task<AnimalDetailDTO> RemoveAsync(AnimalDetailDTO item)
        {
            var mapperModel = _mapper.Map<Animal>(item);

            _animalRepository.Remove(mapperModel);
            await _animalRepository.SaveChangesAsync();

            return item;
        }

        public async Task<AnimalDetailDTO> UpdateAsync(AnimalDetailDTO item)
        {
            var mapperModel = _mapper.Map<Animal>(item);

            _animalRepository.Update(mapperModel);
            await _animalRepository.SaveChangesAsync();

            return item;
        }
    }
}
