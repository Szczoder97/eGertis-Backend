using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Models;

namespace eGertis.Dtos.Order
{
    public class CreateOrderDto
    {
        public int OwnerId {get; set;}
        public int OrderRequestId{get; set;}
        public List<OrderComponent> Products {get; set;}
    }
}