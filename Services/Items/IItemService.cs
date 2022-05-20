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
        Task<ServiceResponse<Item>> GetById(int id);
        Task<ServiceResponse<List<Item>>> GetAll();
        Task<ServiceResponse<List<Item>>> Create(AddItemDto itemDto);
        Task<ServiceResponse<List<Item>>> Update(Item item);
        Task<ServiceResponse<List<Item>>> Delete(int id);
    }
}