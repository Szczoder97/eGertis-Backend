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
        void ChangeRole( int userId, UserRoles role);
        void Delete(int id);
    }
}