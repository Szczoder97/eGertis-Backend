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
        Task<ServiceResponse<GetOrderDto>> GetOrderById(int id);
        Task<ServiceResponse<List<GetOrderDto>>> GetAllOrders();
        Task<ServiceResponse<GetOrderDto>> CreateOrder(CreateOrderDto dto);
        Task<ServiceResponse<GetOrderDto>> UpdateOrder();
    }
}