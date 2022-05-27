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
        Task<ServiceResponse<List<GetOrderDto>>> GetAll();
        Task<ServiceResponse<GetOrderDto>> Create();
        Task<ServiceResponse<List<GetOrderDto>>> Update(int id, UpdateOrderDto dto);
        Task<ServiceResponse<GetOrderDto>> Realize(int id);
        Task<ServiceResponse<List<GetOrderDto>>> Delete(int id);
    }
}