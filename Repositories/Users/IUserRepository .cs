using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Enums;
using eGertis.Models;

namespace eGertis.Repositories.Users
{
    public interface IUserRepository 
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> ChangeRole( int userId, UserRoles role);
        Task<List<User>> Delete(int id);
    }
}