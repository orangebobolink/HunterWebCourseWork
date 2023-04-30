using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using BLL.Services.GenderServices;
using BLL.Services.MethodServices;
using BLL.Services.TypeServices;
using DAL.Entities;
using DAL.Repositories.OrderRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.OrderService
{
    internal class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IMapper _mapper;
        private ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, IMethodService methodService,
            IGenderService genderService, ITypeService typeService, IMapper mapper, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;

            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OrderDTO> AddAsync(OrderDTO item)
        {
            var orderChecked = await _orderRepository.GetAllByPredict(o => (o.Email == item.Email) &&
            (item.FilingDate - o.FilingDate).TotalDays < 1);

            if(orderChecked is not null)
            {
                _logger.LogError("");

                throw new NotFoundException("This email has already submitted an application recently");
            }

            var mapperModel = _mapper.Map<Order>(item);

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
