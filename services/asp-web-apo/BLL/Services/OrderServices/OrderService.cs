using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.UserServices;
using DAL.Entities;
using DAL.Repositories.OrderRepository;
using DAL.Repositories.StatusRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.OrderService
{
    internal class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IStatusRepository _statusRepository;
        private IUserService _userService;
        private IMapper _mapper;
        private ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, IStatusRepository statusRepository, IUserService userService, IMapper mapper, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _statusRepository = statusRepository;
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OrderDTO> AddAsync(OrderDTO item)
        {
            var orderChecked = await _orderRepository.GetAllByPredict(o =>
            (o.User!.Email == item.UserEmail) &&
            ((item.FilingDate - o.FilingDate).TotalDays < 1));

            if(orderChecked.Count() != 0)
            {
                _logger.LogError("");

                throw new NotFoundException("This email has already submitted an application recently");
            }

            var user = await _userService.GetByEmailAsync(item.UserEmail);
            var status = await _statusRepository.GetByNameAsync("todo");
            var mapperModel = _mapper.Map<Order>(item);

            mapperModel.UserId = user.Id;
            mapperModel.User = null;
            mapperModel.StatusId = status!.Id;
            mapperModel.Status = null;

            _orderRepository.Add(mapperModel);
            await _orderRepository.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            var orderChecked = await _orderRepository.GetAllAsync();

            if(orderChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<IEnumerable<OrderDTO>>(orderChecked);

            return mapperModel;
        }

        public async Task<OrderDTO?> GetByIdAsync(int id)
        {
            var orderChecked = await _orderRepository.GetByIdAsync(id);

            if(orderChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            var mapperModel = _mapper.Map<OrderDTO>(orderChecked);

            return mapperModel;
        }

        public async Task<OrderDTO> RemoveAsync(OrderDTO item)
        {
            var huntingSeasonChecked = await _orderRepository.GetByIdAsync(item.Id);

            if(huntingSeasonChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _orderRepository.Remove(huntingSeasonChecked);

            return item;
        }

        public async Task<OrderDTO> UpdateAsync(OrderDTO item)
        {
            var huntingSeasonChecked = await _orderRepository.GetByIdAsync(item.Id);

            if(huntingSeasonChecked is null)
            {
                _logger.LogError("");

                throw new NotFoundException("There is not data yet");
            }

            _orderRepository.Update(huntingSeasonChecked);

            return item;
        }
    }
}
