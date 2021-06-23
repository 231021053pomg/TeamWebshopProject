using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.Database.Context
{
    public class TeamWebshopDbContext : DbContext
    {
        public TeamWebshopDbContext() { }

        public TeamWebshopDbContext(DbContextOptions<TeamWebshopDbContext> options) : base(options) {
            
        }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }

        public DbSet<Credit> Credits { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
