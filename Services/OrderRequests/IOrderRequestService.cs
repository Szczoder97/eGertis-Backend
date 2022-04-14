using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.OrderRequest;
using eGertis.Models;

namespace eGertis.Services.OrderRequests
{
    public interface IOrderRequestService
    {
        Task<ServiceResponse<GetOrderRequestDto>> GetOrderRequestById(int id);
        Task<ServiceResponse<List<GetOrderRequestDto>>> GetOrderRequestsFromSailcamp(int SailCampId);
        Task<ServiceResponse<GetOrderRequestDto>> CreateOrderRequest(CreateOrderRequestDto createOrderRequestDto);
        Task<ServiceResponse<GetOrderRequestDto>> DeactivateOrderRequest(int id);
    }
}