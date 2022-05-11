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
using eGertis.Repositories.Users;

namespace eGertis.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepoitory;


        public OrderService(IOrderRepository orderRepository, IMapper mapper, IAuthService authService, IUserService userService, IUserRepository userRepoitory)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _authService = authService;
            _userRepoitory = userRepoitory;
        }

        public async Task<ServiceResponse<Order>> Create(string title)
        {
            var serviceResponse = new ServiceResponse<Order>();
            var order = new Order();
            order.Title = title;
            var owner = await _userRepoitory.GetById(_authService.GetUserId());
            order.Owner = owner;
            serviceResponse.Data = await _orderRepository.Create(order);
            return serviceResponse; 
        }

        public ServiceResponse<object> Finalize(int id)
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