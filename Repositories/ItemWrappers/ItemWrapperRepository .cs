using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Data;
using eGertis.Models;
using Microsoft.EntityFrameworkCore;

namespace eGertis.Repositories.ItemWrappers
{
    public class ItemWrapperRepository : IItemWrapperRepository
    {
        private readonly DataContext _context;

        public ItemWrapperRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ItemWrapper> Create(ItemWrapper itemWrapper)
        {
            _context.ItemWrappers.Add(itemWrapper);
            await _context.SaveChangesAsync();
            return  itemWrapper;
        }

        public async void Delete(int id)
        {
            var itemWrapper = await GetById(id);
            _context.ItemWrappers.Remove(itemWrapper);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ItemWrapper>> GetAll()
        {
            return await _context.ItemWrappers.ToListAsync();
        }

        public async Task<ItemWrapper> GetById(int id)
        {
            return await _context.ItemWrappers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async void Update(ItemWrapper itemWrapper)
        {
            var wrapperToUpdate = await GetById(itemWrapper.Id);
            wrapperToUpdate.Quantity = itemWrapper.Quantity;
            await _context.SaveChangesAsync();
        }
    }
}