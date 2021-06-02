using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class ItemRepository : IItemRepository
    {
        public Task<Item> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemDiscount()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemDiscription()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemImage()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemPrice()
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetItemsList()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemTags()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemType()
        {
            throw new NotImplementedException();
        }
    }
}
