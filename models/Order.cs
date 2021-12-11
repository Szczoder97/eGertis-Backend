using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.models
{
    public class Order
    {
        public int Id {get; set;}
        public string Owner {get; set;}
        public List<OrderComponent> Products {get; set;}
    }
}