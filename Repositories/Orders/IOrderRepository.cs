using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Models;

namespace eGertis.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<Order> GetById(int id);
        Task<List<Order>> GetAll();
        Task<Order> Create(Order order);
        void Update(Order order);
        void Delete(int id);
        void Finalize(int id);
    }
}