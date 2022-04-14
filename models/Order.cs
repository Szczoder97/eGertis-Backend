using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.Models
{
    public class Order
    {
        public int Id {get; set;}
        public string BoatName {get; set;}
        public DateTime CreationDate {get; set;}
        public List<OrderComponent> Products {get; set;}
        public bool IsFinale {get; set;}
    }
}