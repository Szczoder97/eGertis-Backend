using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Enums;


namespace eGertis.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Email {get; set;}
        public string Name {get; set;}
        public string Surname {get; set;}
        public UserRoles role {get; set;}
        public SailCamp SailCamp {get; set;}
        public List<Order> Orders {get; set;}
    }
}