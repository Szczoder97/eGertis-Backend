using eGertis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.Dtos.Orders
{
    public class GetOrderDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ItemWrapper> Products { get; set; }
        public bool IsRealized { get; set; } = false;

        public GetOrderDto()
        {
        }
        public GetOrderDto(Order order)
        {
            Id = order.Id;
            Title = order.Title;
            CreationDate = order.CreationDate;
            IsRealized = order.IsRealized;

            if (order.Owner != null)
            {
                OwnerId = order.Owner.Id;
            }
            
            if(order.Products != null)
            {
                Products = order.Products;
            }
            
        }
    }
}