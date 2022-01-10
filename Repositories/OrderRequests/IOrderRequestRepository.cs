using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Models;

namespace eGertis.Repositories.FinalOrders
{
    public interface IOrderRequestRepository
    {
        Task<List<OrderRequest>> GetOrderRequestsBySailCamp(SailCamp sailCamp);
        Task<List<OrderRequest>> CreateOrderRequest(OrderRequest orderRequest);
        Task<List<OrderRequest>> DeactivateOrderRequest(int id);
        Task<OrderRequest> GetOrderRequestById(int id);
        Task<List<OrderRequest>> RemoveOrderRequest(int id);
    }
}