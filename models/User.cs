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
        public byte[] PasswordSalt {get; set;}
        public byte[] PasswordHash {get; set;}
        public UserRoles Role {get; set;}
    }
}