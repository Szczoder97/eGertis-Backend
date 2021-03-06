using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Data;
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
        public async Task<User> ChangeRole(int userId, string role)
        {
            var user = await GetById(userId);
            user.Role = role;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> Delete(int id)
        {
            var user = await GetById(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return await GetAll();
        }
    }
}