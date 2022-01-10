using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Data;
using eGertis.Models;
using eGertis.Repositories.FinalOrders;
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

        public async Task<List<OrderRequest>> CreateOrderRequest(OrderRequest orderRequest)
        {
            _context.OrderRequests.Add(orderRequest);
            await _context.SaveChangesAsync();
            return await GetOrderRequestsBySailCamp(orderRequest.SailCamp);
        }

        public async Task<List<OrderRequest>> DeactivateOrderRequest(int id)
        {
            var orderRequest = await GetOrderRequestById(id);
            orderRequest.IsActive = false;
            await _context.SaveChangesAsync();
            return await GetOrderRequestsBySailCamp(orderRequest.SailCamp);
        }

        public async Task<OrderRequest> GetOrderRequestById(int id)
        {
            return await _context.OrderRequests.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<OrderRequest>> GetOrderRequestsBySailCamp(SailCamp sailCamp)
        {
            return await _context.OrderRequests.Where(o => o.SailCamp.Equals(sailCamp)).ToListAsync();
        }

        public async Task<List<OrderRequest>> RemoveOrderRequest(int id)
        {
            var orderRequest = await GetOrderRequestById(id);
            _context.OrderRequests.Remove(orderRequest);
            await _context.SaveChangesAsync();
            return await GetOrderRequestsBySailCamp(orderRequest.SailCamp);
        }
    }
}