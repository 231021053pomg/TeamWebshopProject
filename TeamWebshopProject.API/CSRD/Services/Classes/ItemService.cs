using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class ItemService : IItemService
    {
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
