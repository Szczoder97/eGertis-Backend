using eGertis.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.Models
{
    public class Order
    {    
        public int Id {get; set;}
        public User Owner {get; set;}
        public string Title {get; set;}
        public DateTime CreationDate {get; set;}
        public List<ItemWrapper> Products { get; set; } = new List<ItemWrapper>();
        public bool IsRealized {get; set;} = false;
    }
}