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

        public async Task<List<Item>> Create(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return await GetAll();

        }

        public async Task<List<Item>> GetAll()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetById(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Item>> Delete(int id)
        {
            var item = await GetById(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return await GetAll();
        }

        public async Task<List<Item>> Update(Item item)
        {
            var itemToEdit = await GetById(item.Id);
            itemToEdit.Name = item.Name;
            await _context.SaveChangesAsync();
            return await GetAll();
        }
    }
}