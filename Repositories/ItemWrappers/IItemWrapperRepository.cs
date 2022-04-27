using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Models;

namespace eGertis.Repositories.ItemWrappers
{
    public interface IItemWrapperRepository
    {
        Task<ItemWrapper> GetById(int id);
        Task<List<ItemWrapper>> GetAll();
        Task<ItemWrapper> Create(ItemWrapper itemWrapper);
        void Update(ItemWrapper itemWrapper);
        void Delete(int id);
    }
}