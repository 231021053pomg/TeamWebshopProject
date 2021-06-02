using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class OrderRepository : IOrderRepository
    {
        public Task<Order> GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderPrice()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersList()
        {
            throw new NotImplementedException();
        }
    }
}
