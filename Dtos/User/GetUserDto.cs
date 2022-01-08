using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Enums;

namespace eGertis.Dtos.User
{
    public class GetUserDto
    {
        public int Id {get; set;}
        public string Email {get; set;}
        public string Name {get; set;}
        public string Surname {get; set;}
        public UserRoles Role {get; set;}
    }
}