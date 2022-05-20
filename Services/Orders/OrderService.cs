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

        public async Task<ServiceResponse<GetOrderDto>> Create(string title)
        {
            var serviceResponse = new ServiceResponse<GetOrderDto>();
            var order = new Order();
            order.Title = title;
            var owner = await _userRepoitory.GetById(_authService.GetUserId());
            order.Owner = owner;
            var data = await _orderRepository.Create(order);
            serviceResponse.Data = new GetOrderDto(data);
            return serviceResponse; 
        }


        public async Task<ServiceResponse<List<GetOrderDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetOrderDto>>();
            try 
            {
                var orders = await _orderRepository.GetAll(); 
                serviceResponse.Data = GetOrderDtos(orders);
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
                serviceResponse.Data = new GetOrderDto(order);
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetOrderDto>> Realize(int id)
        {
            var serviceResponse = new ServiceResponse<GetOrderDto>();
            try
            {
                var order = await _orderRepository.Realize(id);
                serviceResponse.Data = new GetOrderDto(order);
                serviceResponse.Message = "Order: " + id + " realized!";
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetOrderDto>>> Update(int id, UpdateOrderDto dto)
        {
            var serviceResponse = new ServiceResponse<List<GetOrderDto>>();
            try
            {
                var productsToSave = dto.Products.Select(prod => _mapper.Map<ItemWrapper>(prod)).ToList();
                var productsToUpdate = new List<ItemWrapper>();
                foreach (var product in productsToSave)
                {
                    productsToUpdate.Add(await _itemWrapperRepository.Create(product));
                }
                var orders = await _orderRepository.Update(id, dto.Title, productsToUpdate);
                serviceResponse.Data = GetOrderDtos(orders);
                serviceResponse.Message = "Saved " + productsToSave.Count + " items!";
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        private List<GetOrderDto> GetOrderDtos(List<Order> orders)
        {
            var data = new List<GetOrderDto>();
                foreach(var order in orders)
                {
                    data.Add(new GetOrderDto(order));
                }
            return data;
        }
    }
}