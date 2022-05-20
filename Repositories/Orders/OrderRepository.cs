using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Data;
using eGertis.Dtos.Orders;
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

        public async Task<Order> Create(Order order)
        {
            order.CreationDate = DateTime.Now;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> Delete(int id)
        {
            var order = await GetById(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return await GetAll();
        }
        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Orders.Include(order => order.Owner)
                .Include(order => order.Products).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> Update(int orderId, string title, List<ItemWrapper> products)
        {
            var orderToUpdate = await GetById(orderId);
            orderToUpdate.Title = title;
            foreach(var product in products)
            {
                orderToUpdate.Products.Add(product);
            }
            await _context.SaveChangesAsync();
            return await GetAll();
        }

        public async Task<Order> Realize(int id)
        {
            var order = await GetById(id);
            order.IsRealized = true;
            await _context.SaveChangesAsync();
            return order;
        }
    }
}