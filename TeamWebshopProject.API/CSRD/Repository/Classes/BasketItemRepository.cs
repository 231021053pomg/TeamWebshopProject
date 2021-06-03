using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Database.Context;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class BasketItemRepository : IBasketItemRepository
    {
        private readonly TeamWebshopDbContext _context;
        public BasketItemRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public Task<BasketItem> Create(BasketItem basketItem)
        {
            throw new NotImplementedException();
        }

        public Task<BasketItem> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BasketItem> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BasketItem> Update(int id, BasketItem basketItem)
        {
            throw new NotImplementedException();
        }
    }
}
