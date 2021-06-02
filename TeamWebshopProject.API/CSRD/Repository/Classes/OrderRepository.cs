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
        private TeamWebshopDbContext _context;
        public OrderRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public Task<Order> Create(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Order> Update(int id, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
