using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Database.Context;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class BasketRepository : IBasketRepository
    {
        private readonly TeamWebshopDbContext _context;
        public BasketRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public Task<Basket> Create(Basket basket)
        {
            throw new NotImplementedException();
        }

        public Task<Basket> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Basket> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Basket>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Basket> Update(int id, Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}
