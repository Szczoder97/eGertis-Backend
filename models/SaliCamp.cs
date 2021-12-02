using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.models
{
    public class SaliCamp
    {
        private int id {get; set;}
        private string name {get; set;}
        private List<FinalOrder> orders {get; set;}
    }
}