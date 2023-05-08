using BLL.DTOs;
using BLL.DTOs.UserDTOs;
using BLL.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseUserDto>> CreateOrder(OrderDTO request)
        {
            var response = await _orderService.AddAsync(request);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseUserDto>> GetAll()
        {
            var response = await _orderService.GetAllAsync();

            return Ok(response);
        }
    }
}
