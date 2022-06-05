using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Dtos.Orders;
using eGertis.Models;

namespace eGertis.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<Order> GetById(int id);
        Task<List<Order>> GetAll();
        Task<Order> Create(Order order);
        Task<List<Order>> Update(int orderId, string title, List<ItemWrapper> products);
        Task<List<Order>> Delete(int id);
        Task<List<Order>> Realize(int id);
    }
}