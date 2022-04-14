using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.Models
{
    public class OrderRequest
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public DateTime CreationDate{get; set;}
        public List<Order> Orders {get; set;}
        public bool IsActive {get; set;}
        
    }
}