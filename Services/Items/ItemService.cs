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
        public async Task<ServiceResponse<List<GetItemDto>>> AddItem(AddItemDto itemDto)
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            var item = _mapper.Map<Item>(itemDto);
            try
            {
                var items = await _itemRepository.AddItem(item);
                serviceResponse.Data = items.Select(i => _mapper.Map<GetItemDto>(i)).ToList();
            }
            catch(Exception e)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> RemoveItem(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            try
            {
                var items = await _itemRepository.RemoveItem(id);
                serviceResponse.Data = items.Select(i => _mapper.Map<GetItemDto>(i)).ToList();
            }
            catch(Exception e)
            {
                serviceResponse.Succes = false;
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
                serviceResponse.Succes = false;
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
                serviceResponse.Succes = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> UpdateItem(UpdateItemDto itemDto)
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            try
            {
                var item = _mapper.Map<Item>(itemDto);
                var items = await _itemRepository.UpdateItem(item);
                serviceResponse.Data = items.Select(i => _mapper.Map<GetItemDto>(i)).ToList();
            }
            catch(Exception e)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
            
        }
    }
}