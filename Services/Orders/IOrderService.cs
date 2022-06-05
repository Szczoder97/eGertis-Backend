using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.Orders;
using eGertis.Models;

namespace eGertis.Services.Orders
{
    public interface IOrderService
    {
        Task<ServiceResponse<GetOrderDto>> GetById(int id);
        Task<ServiceResponse<List<OrderDto>>> GetAll();
        Task<ServiceResponse<OrderDto>> Create();
        Task<ServiceResponse<List<OrderDto>>> Update(int id, UpdateOrderDto dto);
        Task<ServiceResponse<List<OrderDto>>> Realize(int id);
        Task<ServiceResponse<List<OrderDto>>> Delete(int id);
    }
}