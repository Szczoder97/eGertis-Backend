using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.OrderRequests;
using eGertis.Models;

namespace eGertis.Services.OrderRequests
{
    public interface IOrderRequestService
    {
        Task<ServiceResponse<GetOrderRequestDto>> GetOrderRequestById(int id);
        Task<ServiceResponse<List<GetOrderRequestDto>>> GetOrderRequests();
        Task<ServiceResponse<object>> CreateOrderRequest(CreateOrderRequestDto createOrderRequestDto);
        Task<ServiceResponse<object>> DeactivateOrderRequest(int id);
    }
}