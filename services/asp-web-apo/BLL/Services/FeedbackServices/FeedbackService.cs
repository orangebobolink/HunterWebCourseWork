using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using DAL.Entities;
using DAL.Repositories.FeedbackRepository;
using DAL.Repositories.OrderRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.FeedbackServices
{
    internal class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private IMapper _mapper;
        private ILogger<FeedbackService> _logger;

        public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper, ILogger<FeedbackService> logger)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<FeedbackDTO> AddAsync(FeedbackDTO item)
        {
            var mapperModel = _mapper.Map<Feedback>(item);

            _feedbackRepository.Add(mapperModel);
            await _feedbackRepository.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<FeedbackDTO>> GetAllAsync()
        {
            var feedbackChecked = await _feedbackRepository.GetAllAsync();

            if(feedbackChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<IEnumerable<FeedbackDTO>>(feedbackChecked);

            return mapperModel;
        }

        public async Task<FeedbackDTO?> GetByIdAsync(int id)
        {
            var feedbackChecked = await _feedbackRepository.GetByIdAsync(id);

            if(feedbackChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<FeedbackDTO>(feedbackChecked);

            return mapperModel;
        }

        public async Task<FeedbackDTO> RemoveAsync(FeedbackDTO item)
        {
            var feedbackChecked = await _feedbackRepository.GetByIdAsync(item.Id);

            if(feedbackChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _feedbackRepository.Remove(feedbackChecked);

            return item;
        }

        public async Task<FeedbackDTO> UpdateAsync(FeedbackDTO item)
        {
            var feedbackChecked = await _feedbackRepository.GetByIdAsync(item.Id);

            if(feedbackChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _feedbackRepository.Update(feedbackChecked);

            return item;
        }
    }
}
