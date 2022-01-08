using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Enums;

namespace eGertis.Dtos.User
{
    public class ChangeRoleDto
    {
        public int UserId {get; set;}
        public UserRoles Role {get; set;} 
    }
}