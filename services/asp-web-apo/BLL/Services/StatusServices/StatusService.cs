using AutoMapper;
using BLL.DTOs;
using BLL.DTOs.Animal;
using BLL.Exceptions;
using BLL.Services.AnimalServices;
using DAL.Repositories.StatusRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.StatusServices
{
    internal class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private IMapper _mapper;
        private ILogger<StatusService> _logger;

        public StatusService(IStatusRepository statusRepository, IMapper mapper, ILogger<StatusService> logger)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<StatusDTO>> GetAll()
        {
            var statusChecked = await _statusRepository.GetAllAsync();

            if(statusChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<List<StatusDTO>>(statusChecked);

            return mapperModel;
        }
    }
}
