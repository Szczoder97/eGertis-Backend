using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eGertis.Dtos.OrderRequests;
using eGertis.Models;
using eGertis.Repositories.OrderRequests;

namespace eGertis.Services.OrderRequests
{
    public class OrderRequestService : IOrderRequestService
    {
        private readonly IOrderRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public OrderRequestService(IOrderRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<object>> CreateOrderRequest(CreateOrderRequestDto createOrderRequestDto)
        {
            var serviceResponse = new ServiceResponse<object>();
            var orderRequest = new OrderRequest();
            orderRequest.Name = createOrderRequestDto.Name;
            await _requestRepository.CreateOrderRequest(orderRequest);
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> DeactivateOrderRequest(int id)
        {
            var serviceResponse = new ServiceResponse<object>();
            await _requestRepository.DeactivateOrderRequest(id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrderRequestDto>> GetOrderRequestById(int id)
        {
            var serviceResponse = new ServiceResponse<GetOrderRequestDto>();
            try
            {
                var orderRequest = await _requestRepository.GetOrderRequestById(id);
                serviceResponse.Data = _mapper.Map<GetOrderRequestDto>(orderRequest);
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOrderRequestDto>>> GetOrderRequests()
        {
            var serviceResponse = new ServiceResponse<List<GetOrderRequestDto>>();
            try 
            {
                var requests = await _requestRepository.GetOrderRequests();
                serviceResponse.Data = requests.Select(r => _mapper.Map<GetOrderRequestDto>(r)).ToList();
            }
            catch (Exception e) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
    }
}