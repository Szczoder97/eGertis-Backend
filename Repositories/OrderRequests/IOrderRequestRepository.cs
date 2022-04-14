using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Models;

namespace eGertis.Repositories.OrderRequests
{
    public interface IOrderRequestRepository
    {
        Task<List<OrderRequest>> GetOrderRequests();
        Task CreateOrderRequest(OrderRequest orderRequest);
        Task DeactivateOrderRequest(int id);
        Task<OrderRequest> GetOrderRequestById(int id);
        Task RemoveOrderRequest(int id);
    }
}