using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Data;
using eGertis.Models;
using Microsoft.EntityFrameworkCore;

namespace eGertis.Repositories.OrderComponents
{
    public class OrderComponentRepository : IOrderComponentRepository
    {
        private readonly DataContext _context;

        public OrderComponentRepository(DataContext context)
        {
            _context = context;
        }

        public async void CreateOrderComponent(OrderComponent component)
        {
            _context.OrderComponents.Add(component);
            await _context.SaveChangesAsync();
        }

        public async void DeleteOrderComponent(int id)
        {
            var component = await GetOrderComponentById(id);
            _context.OrderComponents.Remove(component);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderComponent>> GetAllOrderComponents()
        {
            return await _context.OrderComponents.ToListAsync();
        }

        public async Task<OrderComponent> GetOrderComponentById(int id)
        {
            return await _context.OrderComponents.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async void UpdateOrderComponent(OrderComponent component)
        {
            var componentToUpdate = await GetOrderComponentById(component.Id);
            componentToUpdate.Quantity = component.Quantity;
            await _context.SaveChangesAsync();
        }
    }
}