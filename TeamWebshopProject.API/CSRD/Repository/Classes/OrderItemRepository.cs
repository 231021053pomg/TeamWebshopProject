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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly TeamWebshopDbContext _context;
        public OrderItemRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> Create(OrderItem orderItem)
        {
            orderItem.CreatedAt = DateTime.Now;
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

                return orderItem;
        }

        public async Task<OrderItem> Delete(int id)
        {
            var orderItem = await _context.OrderItems
                .FirstOrDefaultAsync(o => o.Id == id);
            if (orderItem != null || orderItem.DeletedAt == null)
            {
                orderItem.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();

            }
                return orderItem;
        }

        public async Task<OrderItem> Get(int id)
        {
            return await _context.OrderItems
                .Where(o => o.DeletedAt == null)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<OrderItem>> GetAll()
        {
            return await _context.OrderItems
                .Where(o => o.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<OrderItem> Update(int id, OrderItem UpdatedOrderItem)
        {
            var orderItem = await _context.OrderItems
                 .FirstOrDefaultAsync(o => o.Id == id);

            if (orderItem != null)
            {
                orderItem.EditedAt = DateTime.Now;

                if (UpdatedOrderItem.Order != null)
                    //orderItem.Order = UpdatedOrderItem.Order;

                if (UpdatedOrderItem.Item != null)
                    //orderItem.Item = UpdatedOrderItem.Item;

                orderItem.Quantity = UpdatedOrderItem.Quantity;

                _context.Update(orderItem);
                await _context.SaveChangesAsync();
            }
            return orderItem;

        }
    }
}
