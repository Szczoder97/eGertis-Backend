using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eGertis.Dtos.Orders;
using eGertis.Models;
using eGertis.Repositories.Orders;
using Microsoft.AspNetCore.Http;
using eGertis.Services.Auth;
using eGertis.Services.Users;

namespace eGertis.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public OrderService(IOrderRepository orderRepository, IMapper mapper, IAuthService authService, IUserService userService)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _authService = authService;
            _userService = userService;
        }

        public Task<ServiceResponse<object>> Create()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<object>> Finalize(int id)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                _orderRepository.Finalize(id);
            }
            catch(Exception e) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOrderDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetOrderDto>>();
            try 
            {
                var orders = await _orderRepository.GetAll();
                serviceResponse.Data = orders.Select(order => _mapper.Map<GetOrderDto>(order)).ToList();
            }
            catch(Exception e) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrderDto>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<GetOrderDto>();
            try 
            {
                var order = await _orderRepository.GetById(id);
                serviceResponse.Data = _mapper.Map<GetOrderDto>(order);
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<object>> Update()
        {
            throw new NotImplementedException();
        }
    }
}