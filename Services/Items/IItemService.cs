using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.Item;
using eGertis.models;

namespace eGertis.Services.Items
{
    public interface IItemService
    {
        Task<ServiceResponse<GetItemDto>> GetItem(int id);
        Task<ServiceResponse<List<GetItemDto>>> GetAllItems();
        Task<ServiceResponse<List<GetItemDto>>> AddItem(AddItemDto itemDto);
        Task<ServiceResponse<List<GetItemDto>>> UpdateItem(UpdateItemDto itemDto);
        Task<ServiceResponse<List<GetItemDto>>> DeleteItem(int id);
    }
}