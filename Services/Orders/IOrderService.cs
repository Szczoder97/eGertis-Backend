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
        Task<ServiceResponse<Order>> GetById(int id);
        Task<ServiceResponse<List<Order>>> GetAll();
        Task<ServiceResponse<Order>> Create(string title);
        Task<ServiceResponse<object>> Update(int id, UpdateOrderDto dto);
        Task<ServiceResponse<Order>> Realize(int id);
    }
}