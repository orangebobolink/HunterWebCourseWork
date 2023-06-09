﻿using BLL.DTOs;
using BLL.Interfaces;

namespace BLL.Services.OrderService
{
    public interface IOrderService : IBaseService<OrderDTO>
    {
        public Task<OrderDTO> ChangeStatus(OrderDTO order);
    }
}
