using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.Dtos.Users
{
    public class ChangeRoleDto
    {
        public int UserId {get; set;}
        public string Role {get; set;} 
    }
}