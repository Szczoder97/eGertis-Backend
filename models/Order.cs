using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.models
{
    public class Order
    {
        private int id {get; set;}
        private string owner {get; set;}
        private List<OrderComponent> products {get; set;}
    }
}