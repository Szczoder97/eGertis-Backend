using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.models
{
    public class OrderComponent 
    {
        public int Id {get; set;}
        public Item Item {get; set;}
        public int Quantity{get; set;}
    }
}