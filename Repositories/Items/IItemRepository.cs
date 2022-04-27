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
        Task Create(Item item);
        Task Update(Item item);
        Task Delete(int id);
    }
}