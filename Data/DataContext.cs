using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.Models;
using Microsoft.EntityFrameworkCore;

namespace eGertis.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Item> Items {get; set;}
        public DbSet<ItemWrapper> ItemWrappers {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<User> Users {get; set;}
    }
}