using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Database.Context;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly TeamWebshopDbContext _context;
        public DeliveryRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public Task<Delivery> Create(Delivery delivery)
        {
            throw new NotImplementedException();
        }

        public Task<Delivery> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Delivery> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Delivery>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Delivery> Update(int id, Delivery delivery)
        {
            throw new NotImplementedException();
        }
    }
}
