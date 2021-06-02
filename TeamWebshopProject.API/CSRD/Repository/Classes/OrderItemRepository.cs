using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public Task<OrderItem> GetOrderItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> GetOrderItemQuantity()
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderItem>> GetOrderItemsList()
        {
            throw new NotImplementedException();
        }
    }
}
