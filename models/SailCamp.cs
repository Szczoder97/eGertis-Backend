using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.Models
{
    public class SailCamp
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public List<User> Instructors {get; set;}
        public List<OrderRequest> Orders {get; set;}
    }
}