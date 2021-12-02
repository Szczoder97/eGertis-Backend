using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.models
{
    public class OrderComponent 
    {
        private int id {get; set;}
        private Item item {get; set;}
        private int quantity{get; set;}
    }
}