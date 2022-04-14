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
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<List<User>> ChangeUserRole( int userId, UserRoles role);
        Task<List<User>> RemoveUser(int id);
    }
}