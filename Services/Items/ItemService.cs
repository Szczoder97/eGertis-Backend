using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eGertis.Dtos.Item;
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
        public async Task<ServiceResponse<object>> AddItem(AddItemDto itemDto)
        {
            var serviceResponse = new ServiceResponse<object>();
            var item = _mapper.Map<Item>(itemDto);
            try
            {
                await _itemRepository.AddItem(item);  
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> RemoveItem(int id)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                await _itemRepository.RemoveItem(id);
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> GetAllItems()
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            try
            {
                var items = await _itemRepository.GetAllItems();
                serviceResponse.Data = items.Select(i => _mapper.Map<GetItemDto>(i)).ToList();
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetItemDto>> GetItem(int id)
        {
            var serviceResponse = new ServiceResponse<GetItemDto>();
            try
            {
                var item = await _itemRepository.GetItemById(id);
                serviceResponse.Data = _mapper.Map<GetItemDto>(item);
            }
            catch(Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<object>> UpdateItem(UpdateItemDto itemDto)
        {
            var serviceResponse = new ServiceResponse<object>();
            try
            {
                var item = _mapper.Map<Item>(itemDto);
                await _itemRepository.UpdateItem(item);
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