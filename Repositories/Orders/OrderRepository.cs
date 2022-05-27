using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Constants;
using eGertis.Data;
using eGertis.Dtos.Orders;
using eGertis.Models;
using eGertis.Repositories.Users;
using eGertis.Services.Auth;
using Microsoft.EntityFrameworkCore;

namespace eGertis.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public OrderRepository(DataContext context, IAuthService authService, IUserRepository userRepository)
        {
            _context = context;
            _authService = authService;
            _userRepository = userRepository;
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
            var user = await _userRepository.GetById(_authService.GetUserId());
            var order = await GetById(id);
            if (user.Role.Equals(UserRole.Administrator) ||
                user.Role.Equals(UserRole.SupplyWorker) ||
                order.Owner.Equals(user))
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            return await GetAll();
        }
        public async Task<List<Order>> GetAll()
        {
            if(_authService.GetUserRole().Equals(UserRole.SupplyWorker))
            {
                return await _context.Orders.ToListAsync();
            }
            var user = await _userRepository.GetById(_authService.GetUserId());
            return await _context.Orders.Where(order => order.Owner.Equals(user)).ToListAsync();
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