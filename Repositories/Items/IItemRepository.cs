using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Models;

namespace eGertis.Repositories.Items
{
    public interface IItemRepository
    {
        Task<Item> GetById(int id);
        Task<List<Item>> GetAll();
        Task<List<Item>> Create(Item item);
        Task<List<Item>> Update(Item item);
        Task<List<Item>> Delete(int id);
    }
}