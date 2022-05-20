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
using eGertis.Repositories.ItemWrappers;

namespace eGertis.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepoitory;
        private readonly IItemWrapperRepository _itemWrapperRepository;


        public OrderService(IOrderRepository orderRepository, IMapper mapper, IAuthService authService, IUserService userService, IUserRepository userRepoitory, IItemWrapperRepository itemWrapperRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _authService = authService;
            _userRepoitory = userRepoitory;
            _itemWrapperRepository = itemWrapperRepository;
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


        public async Task<ServiceResponse<List<Order>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<Order>>();
            try 
            {
                var orders = await _orderRepository.GetAll();
                serviceResponse.Data = orders;
                    //orders.Select(order => _mapper.Map<GetOrderDto>(order)).ToList();
            }
            catch(Exception e) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Order>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<Order>();
            try 
            {
                var order = await _orderRepository.GetById(id);
                serviceResponse.Data = order;
                    //_mapper.Map<GetOrderDto>(order);
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Order>> Realize(int id)
        {
            var serviceResponse = new ServiceResponse<Order>();
            try
            {
                serviceResponse.Data = await _orderRepository.Realize(id);
                serviceResponse.Message = "Order: " + id + " realized!";
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> Update(int id, UpdateOrderDto dto)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                var productsToSave = dto.Products.Select(prod => _mapper.Map<ItemWrapper>(prod)).ToList();
                var productsToUpdate = new List<ItemWrapper>();
                foreach (var product in productsToSave)
                {
                    productsToUpdate.Add(await _itemWrapperRepository.Create(product));
                }
                serviceResponse.Data = await _orderRepository.Update(id, dto.Title, productsToUpdate );
                serviceResponse.Message = "Saved " + productsToSave.Count + " items!";
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
    }
}