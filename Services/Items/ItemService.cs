using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eGertis.Data;
using eGertis.Dtos.Item;
using eGertis.models;
using Microsoft.EntityFrameworkCore;

namespace eGertis.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ItemService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetItemDto>>> AddItem(AddItemDto itemDto)
        {
            Item item = _mapper.Map<Item>(itemDto);
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return await GetAllItems();
        }

        public async Task<ServiceResponse<List<GetItemDto>>> DeleteItem(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            try
            {
                Item item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return await GetAllItems();
            }
            catch(Exception e)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = e.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<List<GetItemDto>>> GetAllItems()
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            var items = await _context.Items.ToListAsync();
            serviceResponse.Data = items.Select(i => _mapper.Map<GetItemDto>(i)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetItemDto>> GetItem(int id)
        {
            var serviceResponse = new ServiceResponse<GetItemDto>();
            var item = await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
            serviceResponse.Data = _mapper.Map<GetItemDto>(item);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetItemDto>>> UpdateItem(UpdateItemDto itemDto)
        {
            var serviceResponse = new ServiceResponse<List<GetItemDto>>();
            try
            {
                Item item =  await _context.Items.FirstOrDefaultAsync(i => i.Id == itemDto.Id);
                item.Name = itemDto.Name;
                await _context.SaveChangesAsync();
                return await GetAllItems();
            }
            catch(Exception e)
            {
                serviceResponse.Succes = false;
                serviceResponse.Message = e.Message;
                return serviceResponse;
            }
            
        }
    }
}