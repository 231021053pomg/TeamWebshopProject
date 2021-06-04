using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class OrderItemService : IOrderItemService
    {
        public Task<OrderItem> Create(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> Update(int id, OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
