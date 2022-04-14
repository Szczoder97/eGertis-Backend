using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Data;
using eGertis.Models;
using Microsoft.EntityFrameworkCore;

namespace eGertis.Repositories.Items
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _context;

        public ItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task RemoveItem(int id)
        {
            var item = await GetItemById(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(Item item)
        {
            var itemToEdit = await GetItemById(item.Id);
            itemToEdit.Name = item.Name;
            await _context.SaveChangesAsync();
        }
    }
}