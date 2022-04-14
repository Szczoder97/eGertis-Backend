using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.Item;
using eGertis.Models;

namespace eGertis.Services.Items
{
    public interface IItemService
    {
        Task<ServiceResponse<GetItemDto>> GetItem(int id);
        Task<ServiceResponse<List<GetItemDto>>> GetAllItems();
        Task<ServiceResponse<object>> AddItem(AddItemDto itemDto);
        Task<ServiceResponse<object>> UpdateItem(UpdateItemDto itemDto);
        Task<ServiceResponse<object>> RemoveItem(int id);
    }
}