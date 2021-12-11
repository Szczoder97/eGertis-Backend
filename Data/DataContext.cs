using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eGertis.models;
using Microsoft.EntityFrameworkCore;

namespace eGertis.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Item> Items {get; set;}
        public DbSet<OrderComponent> OrderComponents {get; set;}
    }
}