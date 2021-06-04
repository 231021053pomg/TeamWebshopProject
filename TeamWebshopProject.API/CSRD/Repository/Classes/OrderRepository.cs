using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Database.Context;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TeamWebshopDbContext _context;
        public OrderRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Create(Order order)
        {
            order.CreatedAt = DateTime.Now;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> Delete(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order != null || order.DeletedAt == null)
            {
                order.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return order;
        }

        public async Task<Order> Get(int id)
        {
            return await _context.Orders
                .Where(o => o.DeletedAt == null)
                .FirstOrDefaultAsync(o => o.Id == id);
               
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders
                .Where(o => o.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Order> Update(int id, Order updatedOrder)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order != null)
            {
                order.EditedAt = DateTime.Now;

                if (updatedOrder.Customer != null)
                    //order.Customer = updatedOrder.Customer;

                order.Price = updatedOrder.Price;

                _context.Update(order);
                await _context.SaveChangesAsync();
            }
            return order;
        }
    }
}
