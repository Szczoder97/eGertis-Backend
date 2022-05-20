using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eGertis.Dtos.Items;
using eGertis.Models;
using Microsoft.EntityFrameworkCore;
using eGertis.Repositories.Items;

namespace eGertis.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<Item>>> Create(AddItemDto itemDto)
        {
            var serviceResponse = new ServiceResponse<List<Item>>();
            var item = _mapper.Map<Item>(itemDto);
            try
            {
                serviceResponse.Data = await _itemRepository.Create(item);
                serviceResponse.Message = "Item add: " + item.Name;
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Item>>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<List<Item>>();
            try
            {
                serviceResponse.Data = await _itemRepository.Delete(id);
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Item>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<Item>>();
            try
            {
                serviceResponse.Data = await _itemRepository.GetAll();
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Item>> GetById(int id)
        {
            var serviceResponse = new ServiceResponse<Item>();
            try
            {
                serviceResponse.Data = await _itemRepository.GetById(id);
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Item>>> Update(Item item)
        {
            var serviceResponse = new ServiceResponse<List<Item>>();
            try
            {
                serviceResponse.Data = await _itemRepository.Update(item);
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