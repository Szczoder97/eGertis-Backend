using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Data;
using eGertis.Models;
using eGertis.Repositories.OrderRequests;
using Microsoft.EntityFrameworkCore;

namespace eGertis.Repositories.OrderRequests
{
    public class OrderRequestRepository : IOrderRequestRepository
    {
        private readonly DataContext _context;

        public OrderRequestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateOrderRequest(OrderRequest orderRequest)
        {
            _context.OrderRequests.Add(orderRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeactivateOrderRequest(int id)
        {
            var orderRequest = await GetOrderRequestById(id);
            orderRequest.IsActive = false;
            await _context.SaveChangesAsync();
        }

        public async Task<OrderRequest> GetOrderRequestById(int id)
        {
            return await _context.OrderRequests.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<OrderRequest>> GetOrderRequests()
        {
            return await _context.OrderRequests.ToListAsync();
        }

        public async Task RemoveOrderRequest(int id)
        {
            var orderRequest = await GetOrderRequestById(id);
            _context.OrderRequests.Remove(orderRequest);
            await _context.SaveChangesAsync();
        }
    }
}