using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class BasketItemService : IBasketItemService
    {
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
