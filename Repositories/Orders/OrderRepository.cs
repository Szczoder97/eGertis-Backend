using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Data;
using eGertis.Models;
using Microsoft.EntityFrameworkCore;

namespace eGertis.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async void Create(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var order = await GetById(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public void Finalize(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async void Update(Order order)
        {
            var orderToUpdate = await GetById(order.Id);
            orderToUpdate.Products = order.Products;
            await _context.SaveChangesAsync();
        }
    }
}