using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Models;

namespace eGertis.Dtos.OrderRequests
{
    public class GetOrderRequestDto
    {
         public int Id {get; set;}
        public string Name {get; set;}
        public DateTime CreationDate{get; set;} 
        public List<Order> orders {get; set;}
        public bool IsActive {get; set;}
    }
}