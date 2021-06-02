using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Database.Context;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class ItemRepository : IItemRepository
    {
        private readonly TeamWebshopDbContext _context;
        public ItemRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public Task<Item> Create(Item Item)
        {
            throw new NotImplementedException();
        }

        public Task<Item> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Item> Update(int id, Item item)
        {
            throw new NotImplementedException();
        }
    }
}
