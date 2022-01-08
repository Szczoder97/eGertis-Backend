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
        Task<List<Item>> AddItem(Item item);
        Task<List<Item>> UpdateItem(Item item);
        Task<List<Item>> RemoveItem(int id);
    }
}