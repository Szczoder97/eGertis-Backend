using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.Items;
using eGertis.Models;

namespace eGertis.Services.Items
{
    public interface IItemService
    {
        Task<ServiceResponse<GetItemDto>> GetById(int id);
        Task<ServiceResponse<List<GetItemDto>>> GetAll();
        Task<ServiceResponse<object>> Create(AddItemDto itemDto);
        Task<ServiceResponse<object>> Update(UpdateItemDto itemDto);
        Task<ServiceResponse<object>> Delete(int id);
    }
}