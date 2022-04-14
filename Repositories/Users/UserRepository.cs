using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Data;
using eGertis.Enums;
using eGertis.Models;
using Microsoft.EntityFrameworkCore;

namespace eGertis.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<User>> ChangeUserRole(int userId, UserRoles role)
        {
            var user = await GetUserById(userId);
            user.Role = role;
            await _context.SaveChangesAsync();
            return await GetAllUsers();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> RemoveUser(int id)
        {
            var user = await GetUserById(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return await GetAllUsers();
        }
    }
}