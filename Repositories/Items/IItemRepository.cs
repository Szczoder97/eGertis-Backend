using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Models;

namespace eGertis.Repositories.Items
{
    public interface IItemRepository
    {
        Task<Item> GetItemById(int id);
        Task<List<Item>> GetAllItems();
        Task AddItem(Item item);
        Task UpdateItem(Item item);
        Task RemoveItem(int id);
    }
}