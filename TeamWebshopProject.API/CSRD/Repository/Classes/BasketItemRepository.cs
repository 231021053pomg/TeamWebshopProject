using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class BasketItemRepository : IBasketItemRepository
    {
        public Task<BasketItem> GetBasketItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BasketItem> GetBasketItemQuantity()
        {
            throw new NotImplementedException();
        }

        public Task<List<BasketItem>> GetBasketItems()
        {
            throw new NotImplementedException();
        }
    }
}
