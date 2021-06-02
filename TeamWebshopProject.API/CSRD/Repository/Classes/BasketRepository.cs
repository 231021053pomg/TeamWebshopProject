using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class BasketRepository : IBasketRepository
    {
        public Task<List<Basket>> GetBasket()
        {
            throw new NotImplementedException();
        }

        public Task<Basket> GetBasketCreatedAt()
        {
            throw new NotImplementedException();
        }

        public Task<Basket> GetBasketCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Basket> GetBasketPrice()
        {
            throw new NotImplementedException();
        }

        public Task<Basket> GetBasketQuantity()
        {
            throw new NotImplementedException();
        }
    }
}
