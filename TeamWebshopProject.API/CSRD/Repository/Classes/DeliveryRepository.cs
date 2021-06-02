using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class DeliveryRepository : IDeliveryRepository
    {
        public Task<List<Delivery>> GetDeliveriesList()
        {
            throw new NotImplementedException();
        }

        public Task<Delivery> GetDelivery(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Delivery> GetDeliveryStatus()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrder()
        {
            throw new NotImplementedException();
        }
    }
}
