using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Models;

namespace eGertis.Repositories.OrderComponents
{
    public interface IOrderComponentRepository
    {
        Task<OrderComponent> GetOrderComponentById(int id);
        Task<List<OrderComponent>> GetAllOrderComponents();
        void CreateOrderComponent(OrderComponent component);
        void UpdateOrderComponent(OrderComponent component);
        void DeleteOrderComponent(int id);
    }
}