using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.OrderRequest;
using eGertis.Models;
using eGertis.Repositories.OrderRequests;

namespace eGertis.Services.OrderRequests
{
    public class OrderRequestService : IOrderRequestService
    {
        private readonly IOrderRequestRepository _requestRepository;

        public OrderRequestService(IOrderRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public Task<ServiceResponse<GetOrderRequestDto>> CreateOrderRequest(CreateOrderRequestDto createOrderRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetOrderRequestDto>> DeactivateOrderRequest(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetOrderRequestDto>> GetOrderRequestById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetOrderRequestDto>>> GetOrderRequestsFromSailcamp(int SailCampId)
        {
            throw new NotImplementedException();
        }
    }
}